using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public int Power;
    public int PowerTablo;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Playr"))
        {
            StatsScript.Stats.UpPower(Power);
            StatsScript.Stats.UpTablo(PowerTablo);
        }
    }
}
