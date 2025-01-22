using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScript : AStartScript
{
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        _transform.gameObject.SetActive(true);
    }
}
