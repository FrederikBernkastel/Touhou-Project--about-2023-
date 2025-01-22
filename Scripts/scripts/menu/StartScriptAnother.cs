using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScriptAnother : AStartScript
{
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        if (StorageVarMenuScript.NameButton.TryGetComponent<EndAnimActionScript>(out var comp))
        {
            comp.OnStartScript(null, _transform);
        }
    }
}
