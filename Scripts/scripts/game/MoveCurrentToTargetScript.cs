using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCurrentToTargetScript : AUpdateScript
{
    public LinePathScript TargetTransform;
    public float Speed;
    private Vector3 StartPosition;
    
    public override void UpdateScript(Transform _transform, ref float delta)
    {
        if (StartPosition == Vector3.zero)
            StartPosition = _transform.position;
        
        delta = 
            Vector3.Distance(StartPosition, _transform.position) / 
            Vector3.Distance(StartPosition, TargetTransform.Start.position);
        delta = delta > 1 ? 1 : delta;

        var pos = _transform.position;
        _transform.position += 
            (TargetTransform.Start.position - StartPosition).normalized * Speed * Time.fixedDeltaTime;
        //Debug.Log(TargetTransform.Start.position + " || " + StartPosition);

        if (Vector3.Distance(pos, _transform.position) > 
            Vector3.Distance(pos, TargetTransform.Start.position))
             _transform.position = TargetTransform.Start.position;
    }
}
