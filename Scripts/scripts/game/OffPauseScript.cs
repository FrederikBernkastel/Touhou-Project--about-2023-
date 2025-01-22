using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OffPauseScript : AStartScript
{
    public GameObject QuickMenu;
    public PauseManagementScript Pause;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        Time.timeScale = 1;

        QuickMenu.SetActive(false);

        Pause._DepthOfField.focalLength.Interp(0, 0, 1);

        QuickMenu.GetComponentsInChildren<Transform>().
            FirstOrDefault(u => u.name == "GameObject (1)")?.gameObject.SetActive(false);
        QuickMenu.GetComponentsInChildren<Transform>().
            FirstOrDefault(u => u.name == "GameObject")?.gameObject.SetActive(true);

        Pause.IsPause = false;
    }
}
