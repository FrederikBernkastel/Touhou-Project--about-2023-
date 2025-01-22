using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerDamageScript : MonoBehaviour
{
    public int DefaultCapacity;
    public int MaxCapacity;
    private ObjectPool<BulletEnemyScript> Pool;
    public Transform StorageBullet;
    public BulletEnemyScript Prefab;
    private Coroutine CoroutineTemp;

    private void Start()
    {
        Pool = new ObjectPool<BulletEnemyScript>(() => 
        {
            return GameObject.Instantiate(Prefab, StorageBullet);
        }, pref => 
        {
            pref.gameObject.SetActive(true);
        }, pref => 
        {
            pref.gameObject.SetActive(false);
        }, pref => 
        {
            Destroy(pref.gameObject);
        }, false, DefaultCapacity, MaxCapacity);
    }
    private void Update()
    {
        if (Input.GetKeyDown(SettingsInputScript.Damage))
            CoroutineTemp = this.StartCoroutine(DamageCorutine());
        else if (Input.GetKeyUp(SettingsInputScript.Damage))
            this.StopCoroutine(CoroutineTemp);
    }
    private IEnumerator DamageCorutine()
    {
        while (true)
        {
            yield return null;
        }
    }
}
