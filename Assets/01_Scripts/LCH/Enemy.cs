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
    AngryOpened,
    AngryClosed
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

        stateMachine.AddState(EnemyStateEnum.Idle, new EnemyIdleState(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStateEnum.Chase,new EnemyChaseState(this,stateMachine,"Chase"));
        stateMachine.AddState(EnemyStateEnum.Dead, new EnemyDeadState(this, stateMachine, "Dead"));
        stateMachine.AddState(EnemyStateEnum.Attack, new EnemyAttackState(this, stateMachine, "Attack"));
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
