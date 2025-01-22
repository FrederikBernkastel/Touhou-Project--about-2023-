using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefHealthScript : AStartScript
{
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        _transform.GetComponent<MenuScript>().DefaultButton = SettingsScript.Health - 1;
    }
}
