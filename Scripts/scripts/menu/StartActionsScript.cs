using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActionsScript : MonoBehaviour
{
    public AStartScript[] Scripts;
    public KeyCode Key;

    private void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            foreach (var s in Scripts)
                s.OnStartScript(null, transform);
        }
    }
}
