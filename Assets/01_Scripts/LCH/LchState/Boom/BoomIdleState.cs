using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomIdleState : EnemyState<EnemyStateEnum>
{
    StateManager state;
    public BoomIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        state = enemyBase as StateManager;
    }

    public override void Enter()
    {
        if (!_enemy.IsDie)
        {
            state.WalkChanges();
        }
        base.Enter();
    }
}
