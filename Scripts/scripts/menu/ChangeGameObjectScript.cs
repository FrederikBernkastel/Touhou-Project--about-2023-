using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameObjectScript : AStartScript
{
    public GameObject OldGameObject;
    public GameObject NewGameObject;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        if (OldGameObject)
            OldGameObject.SetActive(false);

        if (NewGameObject)
            NewGameObject.SetActive(true);
    }
}
