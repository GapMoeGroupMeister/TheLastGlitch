using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerAttackState : EnemyState<EnemyStateEnum>
{
    StateManager stateManager;
    public TankerAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        stateManager = enemyBase as StateManager;
    }

    public override void Enter()
    {
      
        stateManager.CloserAttackEnter();
        base.Enter();
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
