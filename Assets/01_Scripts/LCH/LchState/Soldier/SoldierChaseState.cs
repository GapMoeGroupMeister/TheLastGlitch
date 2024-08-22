using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : ChaseInt
{
    public SoldierChaseState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(!_enemy.IsDie)
             ChaseUpdate();
    }
}
