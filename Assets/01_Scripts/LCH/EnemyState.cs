using System;


public class EnemyState<T> : State<T> where T : Enum
{
    public EnemyState(Agent enemyBase, StateMachine<T> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
