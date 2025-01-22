using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabloScript : MonoBehaviour
{
    public int Tablo;
    public int Ochki;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Playr"))
        {
            StatsScript.Stats.UpTablo(Tablo);
            StatsScript.Stats.UpOchki(Ochki);
        }
    }
}
