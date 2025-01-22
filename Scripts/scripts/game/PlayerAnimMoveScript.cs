using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimMoveScript : MonoBehaviour
{
    public Animator Animator;
    public string AnimTagLeftStart;
    public string AnimTagLeftEnd;
    public string AnimTagRightStart;
    public string AnimTagRightEnd;
    
    private void Update()
    {
        if (Input.GetKeyDown(SettingsInputScript.Left))
        {
            Animator.SetTrigger(AnimTagLeftStart);
        }
        else if (Input.GetKeyUp(SettingsInputScript.Left))
        {
            Animator.SetTrigger(AnimTagLeftEnd);
        }
        else if (Input.GetKeyDown(SettingsInputScript.Right))
        {
            Animator.SetTrigger(AnimTagRightStart);
        }
        else if (Input.GetKeyUp(SettingsInputScript.Right))
        {
            Animator.SetTrigger(AnimTagRightEnd);
        }
    }
}
