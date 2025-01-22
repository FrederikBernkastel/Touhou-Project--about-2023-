using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoolMenuScript : AStartScript
{
    public MenuScript Script;
    public bool IsFlag;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        Script.enabled = IsFlag;
    }
}
