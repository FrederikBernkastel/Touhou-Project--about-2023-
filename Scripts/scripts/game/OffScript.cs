using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScript : AStartScript
{
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        _transform.gameObject.SetActive(false);
    }
}
