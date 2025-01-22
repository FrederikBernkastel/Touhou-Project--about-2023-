using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class ScriptableState : MonoBehaviour
{
    [SerializeField] protected ScriptableEngine selectedScriptable;

    #region Public members

    /// <summary>
    /// The currently selected Flowchart.
    /// </summary>
    public virtual ScriptableEngine SelectedScriptable 
    { 
        get => selectedScriptable;
        set => selectedScriptable = value; 
    }

    #endregion
}
