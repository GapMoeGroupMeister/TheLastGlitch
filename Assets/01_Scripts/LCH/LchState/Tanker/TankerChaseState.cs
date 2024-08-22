using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerChaseState : ChaseInt
{
    public TankerChaseState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        ChaseUpdate();
    }
}
