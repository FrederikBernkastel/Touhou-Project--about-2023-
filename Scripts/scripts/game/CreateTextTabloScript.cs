using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateTextTabloScript : MonoBehaviour
{
    public TextMeshProUGUI TextPrefab;
    public int Tablo;
    
    private void OnCollisionEnter2D(Collision2D collisio)
    {
        var text = GameObject.Instantiate(
            TextPrefab, transform.position, Quaternion.identity, 
            GlobalVarybles.StorageArray.StorageEffects.GetComponentInChildren<Canvas>().transform);

        text.text = Tablo.ToString();
    }
}
