using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPathScript : MonoBehaviour
{
    public BezierPath Path;
    public float Speed;
    public bool Aim;
    [Range(0, 1)] public float Delta;

    private void FixedUpdate()
    {
        Delta += Time.fixedDeltaTime * Speed;
        var point = Bezier.GetPoint(
            Path.P0.position, 
            Path.P1.position, 
            Path.P2.position, 
            GlobalVarybles.MainEnemy != null && Aim ? GlobalVarybles.MainEnemy.transform.position : 
                Path.P3.position, 
            Delta);
        transform.position += (point - transform.position).normalized * Time.fixedDeltaTime * Speed;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,
            new(0, 0, Vector3.Angle((point - transform.position).normalized, Vector3.up)), Delta);
    }
    private void OnDrawGizmos() 
    {
        int sigmentsNumber = 20;
        Vector3 preveousePoint = Path.P0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float parameter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(
                Path.P0.position, Path.P1.position, Path.P2.position, Path.P3.position, parameter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }
}
