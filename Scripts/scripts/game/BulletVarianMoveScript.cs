using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVarianMoveScript : MonoBehaviour
{
    public float Radius;
    public float StartSpeed;
    public float StSpeed;
    public float EnSpeed;
    public float Seconds;
}
public class InfoBulletMove : IUpdateBulletMove
{
    public float Radius {get; set;}
    public float StartSpeed {get; set;}
    public float StSpeed {get; set;}
    public float EnSpeed {get; set;}
    public float Seconds {get; set;}
    private float Delta;
    public Vector3 Vector {get; set;}
    private Vector3 StartPosition;
    
    public InfoBulletMove(Vector3 position)
    {
        StartPosition = position;
    }
    public void Update(Transform _transform)
    {
        Delta += Time.fixedDeltaTime / Seconds;
        if (Vector2.Distance(_transform.position, StartPosition) >= Radius)
        {
            _transform.position += 
                Vector * Mathf.Lerp(StSpeed, EnSpeed, Delta > 1 ? 1 : Delta) * Time.fixedDeltaTime;
        }
        else
        {
            _transform.position += Vector * StartSpeed * Time.fixedDeltaTime;
        }
    }
}
public interface IUpdateBulletMove
{
    public void Update(Transform _transform);
}
