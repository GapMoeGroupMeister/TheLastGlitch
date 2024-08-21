using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdleState : EnemyState<EnemyStateEnum>
{
    StateManager stateManager;
    public GunIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        stateManager = enemyBase as StateManager;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent._canMove = false;
        stateManager.WalkChanges();

    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
