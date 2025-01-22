using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoolScript : AStartScript
{
    public ScriptInfo ScriptInfo;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        ScriptInfo.IsLoop = !ScriptInfo.IsLoop;
    }
}
