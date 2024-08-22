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
        base.Enter();
        DeadEnter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            PlayExplosion();
        }
    }
}
