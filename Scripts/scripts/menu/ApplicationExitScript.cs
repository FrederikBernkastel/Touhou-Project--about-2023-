using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationExitScript : AStartScript
{
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        Application.Quit();
    }
}
