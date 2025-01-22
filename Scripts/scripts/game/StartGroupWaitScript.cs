using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGroupWaitScript : AStartScript
{
    public ScriptingFullScript[] Prefabs;
    public int FrameRate;
    private int CurrentFrame;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        StartCoroutine(_OnStartScript(script, _transform));
    }
    private IEnumerator _OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        for (int i = 0; i < Prefabs.Length;)
        {
            CurrentFrame++;

            if (CurrentFrame >= FrameRate)
            {
                CurrentFrame = 0;
                i++;

                Prefabs[i].OnStartScript(script, _transform);
            }
            
            yield return null;
        }
    }
}
