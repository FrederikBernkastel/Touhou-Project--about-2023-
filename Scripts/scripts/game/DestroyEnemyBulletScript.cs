using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBulletScript : MonoBehaviour
{
    public AStartScript[] Script;
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("BulletEnm") || collider.CompareTag("Enm"))
        {
            foreach (var s in Script)
                s.OnStartScript(null, transform);
            GameObject.Destroy(collider.gameObject);
        }
    }
}
