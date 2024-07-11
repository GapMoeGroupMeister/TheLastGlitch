using UnityEngine;

public enum EnemyStateEnum
{
    Idle,
    Attack,
    Chase,
    Dead
}

public enum BossStateEnum
{
    Idle,
    Closed,
    Opened,
    AngryOpened
}
public class Enemy : EnemySetting
{
    public StateMachine<EnemyStateEnum> stateMachine { get; private set; }

    public override void SetDeadState()
    {
        stateMachine.ChangeState(EnemyStateEnum.Dead);
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine<EnemyStateEnum>();
    }

    private void Start()
    {
        stateMachine.InitInitialize(EnemyStateEnum.Idle, this);
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
    }
   
}
