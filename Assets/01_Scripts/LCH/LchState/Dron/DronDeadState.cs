using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronDeadState : DeadInt          
{
    public DronDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
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
