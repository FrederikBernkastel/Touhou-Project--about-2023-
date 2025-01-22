using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public const float MOVE_DISTANCE_TO_PLAYER = 1.5f;          // дистанция начала движения предмета в сторону игрока
    public const float MOVE_SPEED_COEF = 1f;                    // коэффициент увеличения скорости движения
    
    public float Speed;

    // Update is called once per frame
    private void FixedUpdate()
    {
        var dist = Vector2.Distance(transform.position, GlobalVarybles.Player.transform.position);

        if (dist < MOVE_DISTANCE_TO_PLAYER)
        {
            Vector3 dir = (GlobalVarybles.Player.transform.position - transform.position).normalized;
            float _speed = 4f - dist / MOVE_DISTANCE_TO_PLAYER;
            transform.position += new Vector3(dir.x, dir.y, 0) * _speed * 
                MOVE_SPEED_COEF * Time.fixedDeltaTime;
        }
        else
        {
            transform.position += new Vector3(0, -Speed, 0) * Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.Destroy(this.gameObject);
    }
}
