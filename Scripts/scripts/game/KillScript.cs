using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : AStartScript
{
    public AStartScript Script;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        if (StatsScript.Stats.iHealth == 0)
        {
            Script.OnStartScript(script, _transform);
        }
    }
}
