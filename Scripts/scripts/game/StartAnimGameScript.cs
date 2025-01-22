using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimGameScript : AStartScript
{
    public Animator Animator;
    public string NameAnim;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        Animator.Play(NameAnim);
    }
}
