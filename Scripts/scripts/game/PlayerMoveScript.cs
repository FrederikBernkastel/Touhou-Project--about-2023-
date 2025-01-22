using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float Speed;
    
    private void LateUpdate()
    {
        var left = Input.GetKeyDown(SettingsInputScript.Left);
        var right = Input.GetKeyDown(SettingsInputScript.Right);
        var up = Input.GetKeyDown(SettingsInputScript.Up);
        var down = Input.GetKeyDown(SettingsInputScript.Down);
        
        transform.position += new Vector3(
            left ? -1 : right ? 1 : 0, 
            up ? 1 : down ? -1 : 0, 0) * Speed * Time.deltaTime;
    }
}
