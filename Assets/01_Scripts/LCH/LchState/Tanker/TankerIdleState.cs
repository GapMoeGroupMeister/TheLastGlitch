using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerIdleState : EnemyState<EnemyStateEnum>
{
    StateManager stateManager; 

    public TankerIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        stateManager = enemyBase as StateManager;
    }

    public override void Enter()
    {
        if(!_enemy.IsDie)
            stateManager.WalkChanges();
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
