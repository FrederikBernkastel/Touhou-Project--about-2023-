using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fungus;

[System.Serializable]
public class BezierPath
{
    public Transform P0, P1, P2, P3;
}
public class ScriptingFullScript : AStartScript
{
    public ScriptInfo ScriptInfo;
    private float Delta;
    private Coroutine Cor;
    private int CurrentIndex;
    private bool IsStartScript;
    public Vector3 LastPosition {get; private set;}

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        CurrentIndex = 0;
        Delta = 0;

        if (Cor != null)
            this.StopCoroutine(Cor);

        foreach (var s in ScriptInfo.StartFunctions)
            s.OnStartScript(this, transform);
        
        Cor = this.StartCoroutine(OnCoroutineScript());
    }
    public void NextIndex()
    {
        Delta = 1;
    }
    private void Update()
    {
        LastPosition = transform.position;
    }
    private IEnumerator OnCoroutineScript()
    {
        bool[] array_bool = new bool[ScriptInfo._MaxFunctions];
        
        while (CurrentIndex < ScriptInfo.ScriptingArray.Length)
        {
            if (ScriptInfo.IndexEndFinal != 0 && CurrentIndex >= ScriptInfo.IndexEndFinal)
                break;
            
            if (ScriptInfo.IsLoop && CurrentIndex >= ScriptInfo.StartIndex && 
                CurrentIndex < ScriptInfo.EndIndex)
            {
                while (ScriptInfo.IsLoop)
                {
                    for (int i = ScriptInfo.StartIndex; i < ScriptInfo.EndIndex;)
                    {
                        if (!ScriptInfo.IsLoop)
                        {
                            CurrentIndex = ScriptInfo.EndIndex;
                            break;
                        }
                        
                        ScriptInfo.ScriptingArray[i].UpdateFunction.UpdateScript(transform, ref Delta);
                        
                        for (int j = 0; j < ScriptInfo.ScriptingArray[i].StartFunctions.Length; j++)
                        {
                            if (!array_bool[j] && Delta >= ScriptInfo.ScriptingArray[i].
                                StartFunctions[j].Delta)
                            {
                                array_bool[j] = true;

                                foreach (var s in ScriptInfo.ScriptingArray[i].StartFunctions[j].Script)
                                {
                                    s.OnStartScript(this, transform);
                                }
                            }
                        }

                        if (Delta == 1)
                        {
                            for (int h = 0; h < array_bool.Length; h++)
                                array_bool[h] = false;
                            i++;
                            Delta = 0;
                        }
                        
                        yield return null;
                    }

                    if (!ScriptInfo.IsLoop)
                        yield return null;
                }
            }
            else
            {
                ScriptInfo.ScriptingArray[CurrentIndex].UpdateFunction.
                    UpdateScript(transform, ref Delta);
            
                for (int j = 0; j < ScriptInfo.ScriptingArray[CurrentIndex].StartFunctions.Length; j++)
                {
                    if (!array_bool[j] && Delta >= ScriptInfo.ScriptingArray[CurrentIndex].
                        StartFunctions[j].Delta)
                    {
                        array_bool[j] = true;

                        foreach (var s in ScriptInfo.ScriptingArray[CurrentIndex].
                            StartFunctions[j].Script)
                        {
                            s.OnStartScript(this, transform);
                        }
                    }
                }

                if (Delta == 1)
                {
                    for (int h = 0; h < array_bool.Length; h++)
                        array_bool[h] = false;
                    CurrentIndex++;
                    Delta = 0;
                }
            }

            yield return null;
        }

        foreach (var s in ScriptInfo.EndFunctions)
            s.OnStartScript(this, transform);

        yield return null;
    }
}
