using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : AStartScript
{
    public GameObject Prefab;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        GameObject.Instantiate(
            Prefab, transform.position, Quaternion.identity, 
            GlobalVarybles.StorageArray.StorageItems.transform);
    }
}
