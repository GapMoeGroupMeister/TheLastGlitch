using System;


public class EnemyState<T> : State<T> where T : Enum
{

    private Enemy _enemy;
    public EnemyState(Enemy enemyBase, StateMachine<T> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _enemy = enemyBase;
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
