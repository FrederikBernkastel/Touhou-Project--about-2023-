using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimDestroyScript : AStartScript
{
    public Transform StartPoint;
    public PlayerScript PlayerScript;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        this.GetComponent<Animator>().Play("EffectDestroyAnim");

        StatsScript.Stats.DownHealth();

        foreach (var s in GlobalVarybles.StorageArray.StorageBullets
            .GetComponentsInChildren<Transform>())
            if (s.CompareTag("BulletEnm"))
                GameObject.Destroy(s.gameObject);
    }
}
