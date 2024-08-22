using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronIdleState : EnemyState<EnemyStateEnum>
{
    StateManager stateManager;
    public DronIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        stateManager = enemyBase as StateManager;
    }

    public override void Enter()
    {
        base.Enter();
        stateManager.WalkChanges();
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
