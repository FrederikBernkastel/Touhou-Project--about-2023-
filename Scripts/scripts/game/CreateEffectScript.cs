using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEffectScript : AStartScript
{
    public GameObject Prefab;
    public bool IsGUI;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        GameObject.Instantiate(
            Prefab, _transform.position, Quaternion.identity, 
            IsGUI ? GlobalVarybles.StorageArray.StorageEffects.GetComponentInChildren<Canvas>().transform :
            GlobalVarybles.StorageArray.StorageEffects.transform);
    }
}
