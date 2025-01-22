using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimActionScript : AStartScript
{
    public AStartScript[] Scripts;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        foreach (var s in Scripts)
            s.OnStartScript(null, transform);
    }
}
