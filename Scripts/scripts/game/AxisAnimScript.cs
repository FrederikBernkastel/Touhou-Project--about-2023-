using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisAnimScript : AStartScript
{
    public Animator Animator;
    public string LeftNameAnim;
    public string RightNameAnim;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        if ((_transform.position - script.LastPosition).x < 0)
            Animator.Play(LeftNameAnim);
        else
            Animator.Play(RightNameAnim);
    }
}
