using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerDeadState : DeadInt
{
    
    public TankerDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
         DeadEnter();
        base.Enter();
    }

    public override void LateUpdateState()
    {
        base.LateUpdateState();
    }
}
