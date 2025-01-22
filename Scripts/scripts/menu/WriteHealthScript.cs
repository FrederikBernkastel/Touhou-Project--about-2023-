using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteHealthScript : AStartScript
{
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        if (name == "1")
        {
            SettingsScript.Health = 1;
        }
        else if(name == "2")
        {
            SettingsScript.Health = 2;
        }
        else if (name == "3")
        {
            SettingsScript.Health = 3;
        }
        else if (name == "4")
        {
            SettingsScript.Health = 4;
        }
        else if (name == "5")
        {
            SettingsScript.Health = 5;
        }
    }
}
