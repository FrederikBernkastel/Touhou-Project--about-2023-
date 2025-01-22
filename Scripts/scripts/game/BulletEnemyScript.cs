using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    public IUpdateBulletMove UpdateBulletMove {get; set;}

    private void FixedUpdate()
    {
        UpdateBulletMove.Update(transform);
    }
}
