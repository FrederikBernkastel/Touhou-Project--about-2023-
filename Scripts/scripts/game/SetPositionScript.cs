using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionScript : AStartScript
{
    public Transform GameObject;
    public Transform _Transform;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        GameObject.transform.position = _Transform.position;
    }
}
