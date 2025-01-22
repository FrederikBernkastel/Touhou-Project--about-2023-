using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovePathScript : AUpdateScript
{
    public LinePathScript Script;
    public float Seconds;
    
    public override void UpdateScript(Transform _transform, ref float delta)
    {
        delta += Time.fixedDeltaTime / Seconds; delta = delta > 1 ? 1 : delta;

        _transform.position = Vector3.Lerp(Script.Start.position, Script.End.position, delta);
    }
}
