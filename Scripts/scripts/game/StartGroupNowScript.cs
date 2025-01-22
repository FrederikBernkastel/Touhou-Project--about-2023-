using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStartScript : MonoBehaviour
{
    public virtual void OnStartScript(ScriptingFullScript script, Transform _transform) {}
}
public class StartGroupNowScript : AStartScript
{
    public ScriptingFullScript[] Prefabs;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        foreach (var s in Prefabs)
        {
            s.OnStartScript(script, null);
        }
    }
}
