using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptInfo : MonoBehaviour
{

    public FunctionStorScript[] ScriptingArray;
    public bool IsLoop;
    public int StartIndex;
    public int EndIndex;
    public int IndexEndFinal;
    public AStartScript[] StartFunctions;
    public AStartScript[] EndFunctions;
    public int _MaxFunctions = 10;
}
