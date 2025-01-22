using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitScript : AUpdateScript
{
    public float Seconds;
    
    public override void UpdateScript(Transform _transform, ref float delta)
    {
        delta += Time.deltaTime / Seconds; delta = delta > 1 ? 1 : delta;
    }
}
