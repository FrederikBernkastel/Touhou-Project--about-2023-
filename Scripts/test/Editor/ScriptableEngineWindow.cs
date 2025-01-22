using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

#if ON
public class ScriptableEngineWindow : EditorWindow
{
    public const float GridLineSpacingSize = 120;
        public const float GridObjectSnap = 20;
        public const float DefaultBlockHeight = 40;
        public const float BlockMinWidth = 60;
        public const float BlockMaxWidth = 240;
        public const float MinZoomValue = 0.25f;
        public const float MaxZoomValue = 1f;
        public const int HorizontalPad = 20;
        public const int VerticalPad = 5;
        //defines the distance between a down and up for a right click to be a click rather than a drag
        public const float RightClickTolerance = 5f;   
        public const string SearchFieldName = "search";


        protected readonly Color connectionColor = new Color(0.65f, 0.65f, 0.65f, 1.0f);


        protected List<BlockCopy> copyList = new List<BlockCopy>();
        public static List<Block> deleteList = new List<Block>();
        protected Vector2 startDragPosition;
        protected GUIStyle nodeStyle, descriptionStyle, handlerStyle, blockSearchPopupNormalStyle, blockSearchPopupSelectedStyle;
        protected static BlockInspector blockInspector;
        protected int forceRepaintCount;
        protected Texture2D addTexture;
        protected GUIContent addButtonContent;
        protected Texture2D connectionPointTexture;
        protected Rect selectionBox;
        protected Vector2 startSelectionBoxPosition = -Vector2.one;
        protected List<Block> mouseDownSelectionState = new List<Block>();
        protected Color gridLineColor = Color.black;
        // Context Click occurs on MouseDown which interferes with panning
        // Track right click positions manually to show menus on MouseUp
        protected Vector2 rightClickDown = -Vector2.one;
        private string searchString = string.Empty;
        protected Rect searchRect;
        protected Rect popupRect;
        protected List<Block> filteredBlocks = new List<Block>();
        protected int blockPopupSelection = -1;
        protected Vector2 popupScroll;
        protected Flowchart flowchart, prevFlowchart;
        protected int prevVarCount;
        protected Block[] blocks = new Block[0];
        protected Block dragBlock;
        protected bool hasDraggedSelected = false;
        protected static FungusState fungusState;

        static protected VariableListAdaptor variableListAdaptor;

        private bool filterStale = true;
        private bool wasControl;
        private ExecutingBlocks executingBlocks = new ExecutingBlocks();

        private GUIStyle toolbarSeachTextFieldStyle;
        protected GUIStyle ToolbarSeachTextFieldStyle
        {
            get
            {
                if(toolbarSeachTextFieldStyle == null)
                    toolbarSeachTextFieldStyle = GUI.skin.FindStyle("ToolbarSeachTextField");

                return toolbarSeachTextFieldStyle;
            }
        }
        private GUIStyle toolbarSeachCancelButtonStyle;
        private bool didDoubleClick;

        protected GUIStyle ToolbarSeachCancelButtonStyle
        {
            get
            {
                if(toolbarSeachCancelButtonStyle == null)
                    toolbarSeachCancelButtonStyle = GUI.skin.FindStyle("ToolbarSeachCancelButton");

                return toolbarSeachCancelButtonStyle;
            }
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    protected ScriptableEngine scriptable, prevScriptable;
    protected static ScriptableState scriptableState;
    
    [MenuItem("ScriptableEngine/Window")]
    public static void ShowWindow()
    {
        GetWindow<ScriptableEngineWindow>("Scriptable Engine Window");
    }

    public static ScriptableEngine GetScriptableEngine()
    {
        // Using a temp hidden object to track the active Flowchart across 
        // serialization / deserialization when playing the game in the editor.
        if (scriptableState == null)
        {
            scriptableState = GameObject.FindObjectOfType<ScriptableState>();
            if (scriptableState == null)
            {
                GameObject go = new GameObject("_FungusState");
                go.hideFlags = HideFlags.HideInHierarchy;
                scriptableState = go.AddComponent<ScriptableState>();
            }
        }

        if (Selection.activeGameObject != null)
        {
            var fs = Selection.activeGameObject.GetComponent<ScriptableEngine>();
            if (fs != null)
            {
                scriptableState.SelectedScriptable = fs;
            }
        }

        // if (scriptableState.SelectedFlowchart == null)
        // {
        //     variableListAdaptor = null;
        // }
        // else if (variableListAdaptor == null || variableListAdaptor.TargetFlowchart != fungusState.SelectedFlowchart)
        // {
        //     var fsSO = new SerializedObject(fungusState.SelectedFlowchart);
        //     variableListAdaptor = new VariableListAdaptor(fsSO.FindProperty("variables"), fungusState.SelectedFlowchart);
        // }

        return scriptableState.SelectedScriptable;
    }

    internal bool HandleFlowchartSelectionChange()
    {
        scriptable = GetScriptableEngine();
        //target has changed, so clear the blockinspector
        if (scriptable != prevScriptable)
        {
            //blockInspector = null;
            prevScriptable = scriptable;
            //executingBlocks.ClearAll();

            //attempt to defilter previous, if due to scene change these will be null
            //  the regular filter updates will still occur within UpdateBlockCollection
            // for (int i = 0; i < filteredBlocks.Count; i++)
            // {
            //     if (filteredBlocks[i] != null)
            //     {
            //         filteredBlocks[i].FilterState = Block.FilteredState.None;
            //     }
            // }

            // UpdateBlockCollection();

            // if(scriptable != null)
            //     scriptable.ReverseUpdateSelectedCache();//becomes reverse restore selected cache

            Repaint();
            return true;
        }
        return false;
    }

    protected void InitStyles()
    {
        if (nodeStyle == null)
        {
            nodeStyle = new GUIStyle();
        }

        // All block nodes use the same GUIStyle, but with a different background
        nodeStyle.border = new RectOffset(HorizontalPad, HorizontalPad, VerticalPad, VerticalPad);
        nodeStyle.padding = nodeStyle.border;
        nodeStyle.contentOffset = Vector2.zero;
        nodeStyle.alignment = TextAnchor.MiddleCenter;
        nodeStyle.wordWrap = true;

        if (EditorStyles.helpBox != null && descriptionStyle == null)
        {
            descriptionStyle = new GUIStyle(EditorStyles.helpBox);
        }
        descriptionStyle.wordWrap = true;

        if (EditorStyles.whiteLabel != null && handlerStyle == null)
        {
            handlerStyle = new GUIStyle(EditorStyles.label);
        }
        handlerStyle.wordWrap = true;
        handlerStyle.margin.top = 0;
        handlerStyle.margin.bottom = 0;
        handlerStyle.alignment = TextAnchor.MiddleCenter;

        if (blockSearchPopupNormalStyle == null || blockSearchPopupSelectedStyle == null)
        {
            blockSearchPopupNormalStyle = new GUIStyle(GUI.skin.FindStyle("MenuItem"));
        }
        blockSearchPopupNormalStyle.padding = new RectOffset(8, 0, 0, 0);
        blockSearchPopupNormalStyle.imagePosition = ImagePosition.ImageLeft;
        blockSearchPopupSelectedStyle = new GUIStyle(blockSearchPopupNormalStyle);
        blockSearchPopupSelectedStyle.normal = blockSearchPopupSelectedStyle.hover;
        blockSearchPopupNormalStyle.hover = blockSearchPopupNormalStyle.normal;
    }

    public void DeleteBlocks()
    {
            // Delete any scheduled objects
        for (int i = 0; i < deleteList.Count; ++i)
        {
            var deleteBlock = deleteList[i];

            var commandList = deleteBlock.CommandList;
            for (int j = 0; j < commandList.Count; ++j)
            {
                Undo.DestroyObjectImmediate(commandList[j]);
            }

            if (deleteBlock._EventHandler != null)
            {
                Undo.DestroyObjectImmediate(deleteBlock._EventHandler);
            }
            
            if (deleteBlock.IsSelected)
            {
                // Deselect
                scriptable.DeselectBlockNoCheck(deleteBlock);
            }

            Undo.DestroyObjectImmediate(deleteBlock);
        }

        if (deleteList.Count > 0)
        {
            UpdateBlockCollection();
            // Revert to showing properties for the Flowchart
            Selection.activeGameObject = scriptable.gameObject;
            scriptable.ClearSelectedCommands();
            Repaint();
        }

        deleteList.Clear();
    }

    protected void UpdateBlockCollection()
    {
        scriptable = GetScriptableEngine();
        if (scriptable == null)
        {
            blocks = new Block[0];
            filteredBlocks = new List<ScriptableBlock>();
        }
        else
        {
            blocks = scriptable.GetComponents<ScriptableBlock>();
        }
        filterStale = true;
        UpdateFilteredBlocks();
    }

    private void OnGUI()
    {
        // TODO: avoid calling some of these methods in OnGUI because it should be possible
        // to only call them when the window is initialized or a new flowchart is selected, etc.
        if (HandleFlowchartSelectionChange()) return;

        if (scriptable == null)
        {
            GUILayout.Label("No Flowchart scene object selected");
            return;
        }

        InitStyles();
        
        DeleteBlocks();

        UpdateFilteredBlocks();

        HandleEarlyEvents(Event.current);

        // Draw background color / drop shadow
        if (Event.current.type == EventType.Repaint)
        {
            UnityEditor.Graphs.Styles.graphBackground.Draw(
                new Rect(0, 17, position.width, position.height - 17), false, false, false, false
            );
        }

        // Draw blocks and connections
        DrawFlowchartView(Event.current);

        // Draw selection box
        if (Event.current.type == EventType.Repaint)
        {
            if (startSelectionBoxPosition.x >= 0 && startSelectionBoxPosition.y >= 0)
            {
                GUI.Box(selectionBox, "", GUI.skin.FindStyle("SelectionRect"));
            }
        }

        // Draw toolbar, search popup, and variables window
        //  need try catch here as we are now invalidating the drawer if the target flowchart
        //      has changed which makes unity GUILayouts upset and this function appears to 
        //      actually get called partially outside our control
        try
        {
            DrawOverlay(Event.current);
        }
        catch (Exception)
        {
            //Debug.Log("Failed to draw overlay in some way");
        }

        // Handle events for custom GUI
        base.HandleEvents(Event.current);

        if (forceRepaintCount > 0)
        {
            // Redraw on next frame to get crisp refresh rate
            Repaint();
        }

#if UNITY_2020_1_OR_NEWER
        //Force exit gui once repainted
        GUIUtility.ExitGUI();
#endif
    }
}
#endif