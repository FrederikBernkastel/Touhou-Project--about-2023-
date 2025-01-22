using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartFunctionScript : MonoBehaviour
{
    public AStartScript[] Scripts;
    
    public void OnStartScript(int index)
    {
        Scripts[index]?.OnStartScript(null, transform);
    }
}
