using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public AStartScript[] Script;

    private void OnDestroy()
    {
        foreach (var s in Script)
            s.OnStartScript(null, transform);
    }
}
