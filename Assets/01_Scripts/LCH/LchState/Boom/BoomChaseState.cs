using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomChaseState : ChaseInt
{
    public BoomChaseState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        ChaseUpdate();
        base.UpdateState();
    }
}
