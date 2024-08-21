using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronIdleState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public DronIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
         _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent.StopImmediately(true);
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
