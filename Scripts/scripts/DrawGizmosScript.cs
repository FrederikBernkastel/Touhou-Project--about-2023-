using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DrawGizmosScript : MonoBehaviour
{
    public BezierPath Path;
    public float Radius;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(Path.P0.position, Path.P1.position);
        Gizmos.DrawLine(Path.P1.position, Path.P2.position);
        Gizmos.DrawLine(Path.P2.position, Path.P3.position);
        
        Gizmos.color = Color.white;
        
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

        Gizmos.color = Color.yellow;
        
        Gizmos.DrawSphere(Path.P0.position, Radius);
        Gizmos.DrawSphere(Path.P1.position, Radius);
        Gizmos.DrawSphere(Path.P2.position, Radius);
        Gizmos.DrawSphere(Path.P3.position, Radius);
    }
}
