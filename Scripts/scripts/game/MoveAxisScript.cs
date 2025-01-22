using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisScript : MonoBehaviour
{
    public float Speed;
    public Vector3 Axis;
    
    private void FixedUpdate()
    {
        transform.position += Axis * Time.fixedDeltaTime * Speed;
    }
}
