using UnityEngine;

public enum EnemyStateEnum
{
    Idle,
    Attack,
    Chase,
    Dead,
}
public class Enemy : AttackRange
{
    public StateMachine<EnemyStateEnum> stateMachine { get; private set; }

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
    public override void SetDeadState()
    {
        
    }

    public override void AnimationEndTrigger()
    {
       
    }
}
