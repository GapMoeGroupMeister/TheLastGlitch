using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum BossStateEnum
{
    Idle,
    Closed,
    Opened,
    AngryOpened,
    Dead,
    Opening,
    Closing
}

public enum PatternTypeEnum
{
    EnemySpawn,
    CoreBomb,
    LaserShoot,
    None
}

public class MGSY : EnemySetting
{
    public string state = null;
    public StateMachine<BossStateEnum> StateMachine { get; private set; }

    public Animator mgsyAnimator = null;

    public int? isRunningHash = null;

    public Dictionary<Enum, MGSYPattern> patternDic = new Dictionary<Enum, MGSYPattern>();

        

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<BossStateEnum>();

        StateMachine.AddState(BossStateEnum.Idle, new MgsyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(BossStateEnum.Closed, new MgsyClosedState(this, StateMachine, "Closed"));
        StateMachine.AddState(BossStateEnum.Opened, new MgsyOpenedState(this, StateMachine, "Opened"));
        StateMachine.AddState(BossStateEnum.AngryOpened, new MgsyAngryOpenedState(this, StateMachine, "AngryOpened"));
        StateMachine.AddState(BossStateEnum.Dead, new MgsyDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(BossStateEnum.Opening, new MGSYOpeningState(this, StateMachine, "Opening"));
        StateMachine.AddState(BossStateEnum.Closing, new MGSYClosingState(this, StateMachine, "Closing"));
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

    public void Opening2Opened()
    {
        if (HealthComponent.GetCurrentHP() > HealthComponent.maxHealth)
        {
            StateMachine.ChangeState(BossStateEnum.Opened);
        }
        else
        {
            StateMachine.ChangeState(BossStateEnum.AngryOpened);
        }
    }

    public void Coroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine.ToString());
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

}

