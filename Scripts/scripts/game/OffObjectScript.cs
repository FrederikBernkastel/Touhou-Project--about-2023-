using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffObjectScript : MonoBehaviour
{
    public string sTag;
    
    private void Start()
    {
        foreach (var s in GlobalVarybles.StorageArray.StorageEnemys
                .GetComponentsInChildren<Transform>())
        {
            if (s.CompareTag(sTag))
            {
                s.gameObject.SetActive(false);
            }
        }
    }
}
