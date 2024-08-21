using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSY : EnemySetting
{
    [SerializeField] private GameObject testEnemyPrefab = null;
    [SerializeField] protected Health health = null;
    public string state = null;
    public StateMachine<BossStateEnum> StateMachine { get; private set; }
    public GameObject test => testEnemyPrefab;

    public Animator mgsyAnimator = null;

    public int ?isRunningHash = null;

    public Action OnCoreExplosion;
    public Action OnMobSpawn;
    public Action OnElectricExplosion;

    protected override void Awake()
    {
        base.Awake();
        health = GetComponent<Health>();
        StateMachine = new StateMachine<BossStateEnum>();

        StateMachine.AddState(BossStateEnum.Idle, new MgsyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(BossStateEnum.Closed, new MgsyClosedState(this, StateMachine, "Closed"));
        StateMachine.AddState(BossStateEnum.Opened, new MgsyOpenedState(this, StateMachine, "Opened"));
        StateMachine.AddState(BossStateEnum.AngryOpened, new MgsyAngryOpenedState(this, StateMachine, "AngryOpened"));
        StateMachine.AddState(BossStateEnum.Dead, new MgsyDeadState(this, StateMachine, "Dead"));
        StateMachine.InitInitialize(BossStateEnum.Idle, this);
    }
    
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    public override void SetDeadState()
    {
        StateMachine.ChangeState(BossStateEnum.Dead);
    }

    public Collider2D GetPlayerInRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, detectRadius, contactFilter, _colliders);
        Debug.Log(count);
        return count > 0 ? _colliders[0] : null;
    }

    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }

    public void SpawnEntity(GameObject entities)
    {
        Instantiate(entities);
    }
}
