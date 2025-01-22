using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ScriptableEngine))]
public class ScriptableEngineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open Scriptable Engine Window"))
        {
            //ScriptableEngineWindow.ShowWindow();
        }
    } 
}
