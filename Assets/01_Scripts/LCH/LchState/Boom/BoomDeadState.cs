using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDeadState : DeadInt
{
    public BoomDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        DeadEnter();
    }

    public override void UpdateState()
    {
        if (_endTriggerCalled)
        {
            PlayExplosion();
        }
        base.UpdateState();
    }
}