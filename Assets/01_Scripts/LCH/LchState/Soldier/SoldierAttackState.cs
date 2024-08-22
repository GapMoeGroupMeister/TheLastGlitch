using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : EnemyState<EnemyStateEnum>
{
    StateManager stateManager;
    public SoldierAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        stateManager = enemyBase as StateManager;
    }

    public override void Enter()
    {
        base.Enter();
        stateManager.CloserAttackEnter();
    }

    public override void UpdateState()
    {
        if (_endTriggerCalled)
        {
            stateManager.EnemyAttack();
        }
        base.UpdateState();
    }
}
