using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowScript : MonoBehaviour
{
    public Animator Animator;
    
    public void OnTriggerAnim()
    {
        Animator.enabled = false;
    }
}
