using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitBossScript : AUpdateScript
{
    public float Seconds;
    public TextMeshProUGUI Text;
    public float Speed;
    
    public override void UpdateScript(Transform _transform, ref float delta)
    {
        delta += Time.deltaTime / Seconds * Speed; delta = delta > 1 ? 1 : delta;

        Text.text = ((int)(Seconds - Seconds * delta)).ToString();
    }
}
