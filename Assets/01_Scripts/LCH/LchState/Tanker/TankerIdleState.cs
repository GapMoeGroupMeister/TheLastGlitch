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
      
        stateManager.WalkChanges();
        if (_enemy.IsDie)
        {
            _enemy.StateMachine.ChangeState(EnemyStateEnum.Dead);
        }
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
