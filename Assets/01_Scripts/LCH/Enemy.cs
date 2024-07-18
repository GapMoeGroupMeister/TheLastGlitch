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
    public StateMachine<EnemyStateEnum> StateMachine { get; private set; }


    public override void SetDeadState()
    {
        StateMachine.ChangeState(EnemyStateEnum.Dead);
    }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<EnemyStateEnum>();

        StateMachine.AddState(EnemyStateEnum.Idle, new EnemyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Chase,new EnemyChaseState(this,StateMachine,"Chase"));
        StateMachine.AddState(EnemyStateEnum.Dead, new EnemyDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Attack, new EnemyAttackState(this, StateMachine, "Attack"));

        StateMachine.InitInitialize(EnemyStateEnum.Idle, this);
    }

    private void Start()
    {
        StateMachine.InitInitialize(EnemyStateEnum.Idle, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        if(targetTrm != null && IsDie == false)
        {
            HandleSpriteFlip(targetTrm.position);
        }
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }

}
