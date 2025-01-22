using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AMonoBehaviour
{
    public virtual void Awake(MonoBehaviour script) {}
    public virtual void Start(MonoBehaviour script) {}
    public virtual void FixedUpdate(MonoBehaviour script) {}
    public virtual void OnDestroy(MonoBehaviour script) {}
    public virtual void OnTriggerEnter2D(MonoBehaviour script, Collider2D collider) {}
}
[System.Serializable]
public class AnimPlayer : AMonoBehaviour
{
    // private Animator AnimatorMove;
    // private PlayerInput PlayerInput;

    // public override void Awake(MonoBehaviour script)
    // {
    //     PlayerInput = script.GetComponent<PlayerInput>();
    //     AnimatorMove = script.GetComponent<Animator>();
    // }
    // public override void Start(MonoBehaviour script)
    // {
    //     PlayerInput.actions["StartAnimLeftMove"].performed += context => OnPressLeftArrow(context);
    //     PlayerInput.actions["StopAnimLeftMove"].performed += context => OnReleaseLeftArrow(context);
    //     PlayerInput.actions["StartAnimRightMove"].performed += context => OnPressRightArrow(context);
    //     PlayerInput.actions["StopAnimRightMove"].performed += context => OnReleaseRightArrow(context);
    // }
    // private void OnPressLeftArrow(InputAction.CallbackContext context)
    // {
    //     AnimatorMove.SetTrigger("StartLeftMove");
    // }
    // private void OnReleaseLeftArrow(InputAction.CallbackContext context)
    // {
    //     AnimatorMove.SetTrigger("StopLeftMove");
    // }
    // private void OnPressRightArrow(InputAction.CallbackContext context)
    // {
    //     AnimatorMove.SetTrigger("StartRightMove");
    // }
    // private void OnReleaseRightArrow(InputAction.CallbackContext context)
    // {
    //     AnimatorMove.SetTrigger("StopRightMove");
    // }
}
[System.Serializable]
public class MovePlayer : AMonoBehaviour
{
    // public float Speed;
    // private Vector2 Velocity;
    // private PlayerInput PlayerInput;
    // public Animator AnimatorSlow;
    // public GameObject SlowObject;

    // public override void Awake(MonoBehaviour script)
    // {
    //     PlayerInput = script.GetComponent<PlayerInput>();
    // }
    // public override void Start(MonoBehaviour script)
    // {
    //     PlayerInput.actions["Move"].performed += context => OnMove(context);
    //     PlayerInput.actions["Move"].canceled += context => OnMove(context);

    //     PlayerInput.actions["StartSlow"].performed += context => OnStartSlow(context);
    //     PlayerInput.actions["StopSlow"].canceled += context => OnStopSlow(context);
    // }
    // private void OnMove(InputAction.CallbackContext context)
    // {
    //     Velocity = context.ReadValue<Vector2>();
    // }
    // private void OnStartSlow(InputAction.CallbackContext context)
    // {
    //     AnimatorSlow.enabled = true;
    //     AnimatorSlow.Play("StartSlowAnim");
    //     Speed *= 0.5f;
    //     SlowObject.SetActive(true);
    // }
    // private void OnStopSlow(InputAction.CallbackContext context)
    // {
    //     AnimatorSlow.SetTrigger("StopAnim");
    //     Speed *= 2;
    //     SlowObject.SetActive(false);
    // }
    // public override void FixedUpdate(MonoBehaviour script)
    // {
    //     Vector3 vector3 = new(Velocity.x, Velocity.y, 0);
    //     script.transform.position += vector3 * Speed * Time.fixedDeltaTime;
    // }
}
[System.Serializable]
public class StagesBulletPlayer
{
    public StageBullet StageBullet;
    public StageBullet StageBulletUlta;
}
[System.Serializable]
public class StageBullet
{
    public GameObject Prefab = default!;
    public BezierPath[] Paths = default!;
    public float Speed;
    public bool Aim;
}
[System.Serializable]
public class DamagePlayer : AMonoBehaviour
{
    // private PlayerInput PlayerInput;
    // private Vector2 Delta;
    // public Vector2 FireAndFireUltaRate;
    // private bool IsDamage;
    // private int CurrentStage;
    // public StagesBulletPlayer[] StagesBulletPlayer;
    // private StagesBulletPlayer CurrentStageBullet;

    // public override void Awake(MonoBehaviour script)
    // {
    //     PlayerInput = script.GetComponent<PlayerInput>();
    // }
    // public override void Start(MonoBehaviour script)
    // {
    //     PlayerInput.actions["StartDamage"].performed += OnStartDamage;
    //     PlayerInput.actions["StopDamage"].canceled += OnStopDamage;

    //     ResetStage();
    // }
    // public void NextStage()
    // {
    //     CurrentStage = CurrentStage < StagesBulletPlayer.Length - 1 ? CurrentStage + 1 : CurrentStage;

    //     CurrentStageBullet = StagesBulletPlayer[CurrentStage];
    // }
    // public void LastStage()
    // {
    //     CurrentStage = CurrentStage > 0 ? CurrentStage - 1 : CurrentStage;

    //     CurrentStageBullet = StagesBulletPlayer[CurrentStage];
    // }
    // public void ResetStage()
    // {
    //     CurrentStage = 0;

    //     CurrentStageBullet = StagesBulletPlayer[CurrentStage];
    // }
    // public override void FixedUpdate(MonoBehaviour script)
    // {
    //     Damage();
    //     DamageUlta();
    // }
    // private void Damage()
    // {
    //     if (CurrentStageBullet.StageBullet != null && IsDamage && Time.time > Delta.x)
    //     {
    //         foreach (var s in CurrentStageBullet.StageBullet.Paths)
    //         {
    //             var gameObject = GameObject.Instantiate(
    //                 CurrentStageBullet.StageBullet.Prefab, s.P0.position, Quaternion.identity, 
    //                 GlobalVarybles.StorageArray.StorageBullets.transform);

    //             var component = gameObject.GetComponent<BulletPathScript>();

    //             component.Aim = CurrentStageBullet.StageBullet.Aim;
    //             component.Speed = CurrentStageBullet.StageBullet.Speed;
    //             component.Path = s;
    //         }
            
    //         Delta = new Vector2(Time.time + FireAndFireUltaRate.x, Delta.y);
    //     }
    // }
    // private void DamageUlta()
    // {
    //     if (CurrentStageBullet.StageBulletUlta != null && IsDamage && Time.time > Delta.y)
    //     {
    //         foreach (var s in CurrentStageBullet.StageBulletUlta.Paths)
    //         {
    //             var gameObject = GameObject.Instantiate(
    //                 CurrentStageBullet.StageBulletUlta.Prefab, s.P0.position, Quaternion.identity, 
    //                 GlobalVarybles.StorageArray.StorageBullets.transform);

    //             var component = gameObject.GetComponent<BulletPathScript>();

    //             component.Aim = CurrentStageBullet.StageBulletUlta.Aim;
    //             component.Speed = CurrentStageBullet.StageBulletUlta.Speed;
    //             component.Path = s;
    //         }
            
    //         Delta = new Vector2(Delta.x, Time.time + FireAndFireUltaRate.y);
    //     }
    // }
    // private void OnStartDamage(InputAction.CallbackContext context)
    // {
    //     IsDamage = true;
    // }
    // private void OnStopDamage(InputAction.CallbackContext context)
    // {
    //     IsDamage = false;
    // }
}
public class PlayerScript : MonoBehaviour
{
    [HideInInspector] public AnimPlayer AnimPlayer;
    public MovePlayer MovePlayer;
    public DamagePlayer DamagePlayer;

    private void Awake()
    {
        AnimPlayer.Awake(this);
        MovePlayer.Awake(this);
        DamagePlayer.Awake(this);
    }
    private void Start()
    {
        AnimPlayer.Start(this);
        MovePlayer.Start(this);
        DamagePlayer.Start(this);
    }
    private void FixedUpdate()
    {
        AnimPlayer.FixedUpdate(this);
        MovePlayer.FixedUpdate(this);
        DamagePlayer.FixedUpdate(this);
    }
    private void OnDestroy()
    {
        AnimPlayer.OnDestroy(this);
        MovePlayer.OnDestroy(this);
        DamagePlayer.OnDestroy(this);
    }
}
