using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlowScript : MonoBehaviour
{
    public PlayerMoveScript Script;
    public Animator Animator;
    public string AnimTagStart;
    public string AnimTagEnd;
    private float SpeedTemp;
    
    private void Update()
    {
        if (Input.GetKeyDown(SettingsInputScript.Slow))
        {
            SpeedTemp = Script.Speed;
            Script.Speed *= 0.5f;
            Animator.SetTrigger(AnimTagStart);
        }
        else if (Input.GetKeyUp(SettingsInputScript.Slow))
        {
            Script.Speed = SpeedTemp;
            Animator.SetTrigger(AnimTagEnd);
        }
    }
}
