using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmosLineScript : MonoBehaviour
{
    public Transform Start;
    public Transform End;
    public float Radius;

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;

        Gizmos.DrawLine(Start.position, End.position);

        Gizmos.color = Color.yellow;
        
        Gizmos.DrawSphere(Start.position, Radius);
        Gizmos.DrawSphere(End.position, Radius);
    }
}
