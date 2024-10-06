using System;


public class EnemyState<T> : State<T> where T : Enum
{
<<<<<<< HEAD:Assets/01_Scripts/LCH/EnemyState.cs
    public EnemyState(Agent enemyBase, StateMachine<T> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
=======

    protected Enemy _enemy;
    public EnemyState(Enemy enemyBase, StateMachine<T> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
>>>>>>> origin/Develop:Assets/01_Scripts/LCH/StateManager/EnemyState.cs
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
