using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScriptStageOne : AStartScript
{
    public BulletEnemyScript Prefab;
    public int NumberBullets;
    public int NumberDamage;
    public int FrameRate;
    public int OffsetAngle;
    public BulletVarianMoveScript VarianMove;
    private Coroutine Corutine;
    private int CurrentFrame;
    private int CurrentDamage;
    public bool IsRandom;
    private int CurrentOffsetAngle;

    public override void OnStartScript(ScriptingFullScript script, Transform _transform)
    {
        CurrentFrame = FrameRate;
        CurrentDamage = 0;
        CurrentOffsetAngle = 0;

        Corutine = StartCoroutine(CorutineDamage(script, _transform));
    }
    private IEnumerator CorutineDamage(ScriptingFullScript script, Transform _transform)
    {
        while (CurrentDamage < NumberDamage)
        {
            CurrentFrame++;

            if (CurrentFrame >= FrameRate)
            {
                CurrentDamage++;
                CurrentOffsetAngle = IsRandom ? Random.Range(0, 360) : CurrentOffsetAngle + OffsetAngle;
                CurrentFrame = 0;
                
                for (int i = 0, a = 0; i < NumberBullets; i++, a += 360 / NumberBullets)
                {
                    var gameObject = GameObject.Instantiate(
                        Prefab, _transform.position, Quaternion.identity, 
                        GlobalVarybles.StorageArray.StorageBullets.transform);

                    InfoBulletMove scr = new(_transform.position)
                    {
                        Radius = VarianMove.Radius,
                        StartSpeed = VarianMove.StartSpeed,
                        StSpeed = VarianMove.StSpeed,
                        EnSpeed = VarianMove.EnSpeed,
                        Seconds = VarianMove.Seconds,
                        Vector = new(
                            Mathf.Sin((a + CurrentOffsetAngle) * Mathf.Deg2Rad), 
                            Mathf.Cos((a + CurrentOffsetAngle) * Mathf.Deg2Rad)),
                    };
                    
                    gameObject.GetComponent<BulletEnemyScript>().UpdateBulletMove = scr;
                }
            }

            yield return null;
        }
        
        yield return null;
    }
}
