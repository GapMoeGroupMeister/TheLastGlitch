using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDeadState : DeadInt
{
    public SoldierDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        DeadEnter();
        base.Enter();
    }

    public override void LateUpdateState()
    {
        if (_endTriggerCalled)
        {
            //PlayExplosion();
            EnemyPush();
        }
        base.LateUpdateState();
    }
}
