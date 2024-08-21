using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronDeadState : EnemyState<EnemyStateEnum>
{
    public DronDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
