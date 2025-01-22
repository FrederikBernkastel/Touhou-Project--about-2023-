using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorUIScript : AStartScript
{
    public Image[] Images;
    public Color _Color;
    
    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        foreach (var s in Images)
            s.color = _Color;
    }
}
