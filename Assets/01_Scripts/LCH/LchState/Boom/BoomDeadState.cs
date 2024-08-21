using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDeadState : EnemyState<EnemyStateEnum>
{
    public BoomDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
}
