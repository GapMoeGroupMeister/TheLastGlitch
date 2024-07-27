using UnityEngine;

public enum EnemyStateEnum
{
    Idle,
    Attack,
    Chase,
    Walk,
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
        StateMachine.AddState(EnemyStateEnum.Walk, new EnemyWalkState(this, StateMachine, "Walk"));
    }

    private void Start()
    {
        StateMachine.InitInitialize(EnemyStateEnum.Idle, this);
    }

    private void Update()
    {
        Debug.Log(StateMachine.CurrentState);
        StateMachine.CurrentState.UpdateState();
        if(targetTrm != null && IsDie == false)
        {
            HandleSpriteFlip(targetTrm.position);
        }

        if(MovementComponent._xMove < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        Debug.Log(MovementComponent._xMove);
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }

}
