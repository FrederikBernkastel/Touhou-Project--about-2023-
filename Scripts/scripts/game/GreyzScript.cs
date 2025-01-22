using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyzScript : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    
    private void Update()
    {
        var main = ParticleSystem.main;

        int cell = 0;
        main.simulationSpeed = 0;

        foreach (Transform s in GlobalVarybles.StorageArray.StorageBullets.transform)
        {
            if (s.CompareTag("BulletEnm"))
            {
                if (Vector3.Distance(s.position, transform.position) < 0.7f && s.localScale.z != 2)
                {
                    cell++;
                    
                    s.localScale = new(s.localScale.x, s.localScale.y, 2);
                    main.simulationSpeed = cell > 5 ? 7 : cell * 5 / 5 + 2;

                    StatsScript.Stats.UpGreyz(1);
                }
            }
        }
    }
}
