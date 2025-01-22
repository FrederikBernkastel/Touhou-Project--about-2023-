using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemyScript : MonoBehaviour
{
    public int HP;
    public Image Image;
    public bool IsAlways;
    public bool IsBoss;
    public ScriptingFullScript Script;
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "BulletPlayer")
        {
            if (!IsAlways)
            {
                HP = HP - 1 < 0 ? 0 : HP - 1;
                
                if (IsBoss)
                {
                    //Power.rectTransform.sizeDelta
                }
            }

            if (HP <= 0)
            {
                gameObject.SetActive(false);

                if (IsBoss)
                {
                    Script.NextIndex();
                }
            }

            GameObject.Destroy(collider.gameObject);
        }
    }
    private void OnDestroy()
    {
        ChangeMainEnemy();
    }
    public void ChangeMainEnemy()
    {
        if (GlobalVarybles.MainEnemy != null && 
            GlobalVarybles.MainEnemy.transform.position == transform.position)
        {
            GameObject enemy = default;

            foreach (var s in GlobalVarybles.StorageArray.StorageEnemys
                .GetComponentsInChildren<Transform>())
            {
                if (GlobalVarybles.MainEnemy.transform.position != s.position &&
                    s.CompareTag("Enm") && s.gameObject.activeSelf)
                {
                    enemy = s.gameObject;

                    break;
                }
            }
            
            GlobalVarybles.MainEnemy = enemy;
        }
    }
    private void OnEnable()
    {
        GlobalVarybles.MainEnemy ??= gameObject;
    }
    private void OnDisable()
    {
        ChangeMainEnemy();
    }
}
