using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTwoAnim : MonoBehaviour
{
    public Animator Animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimStartTwo()
    {
        Animator.enabled = true;
    }
}
