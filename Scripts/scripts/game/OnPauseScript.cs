using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPauseScript : AStartScript
{
    public GameObject QuickMenu;
    public PauseManagementScript Pause;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        Time.timeScale = 0;

        QuickMenu.SetActive(true);

        Pause._DepthOfField.focalLength.Interp(32, 32, 1);

        Pause.IsPause = true;
    }
}
