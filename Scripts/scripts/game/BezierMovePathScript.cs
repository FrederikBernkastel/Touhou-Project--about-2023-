using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BezierMovePathScript : AUpdateScript
{
    public BezierPathScript Script;
    public float Seconds;
    
    public override void UpdateScript(Transform _transform, ref float delta)
    {
        delta += Time.deltaTime / Seconds; delta = delta > 1 ? 1 : delta;

        _transform.position = Bezier.GetPoint(
            Script.BezierPath.P0.position,
            Script.BezierPath.P1.position,
            Script.BezierPath.P2.position,
            Script.BezierPath.P3.position,
            delta);
    }
}
