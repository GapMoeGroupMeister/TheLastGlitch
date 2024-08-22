using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : EnemyState<EnemyStateEnum>
{
    StateManager stateManager;
    public SoldierIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        stateManager = enemyBase as StateManager;
    }

    public override void Enter()
    {
        base.Enter();
        stateManager.WalkChanges();

    }
}
