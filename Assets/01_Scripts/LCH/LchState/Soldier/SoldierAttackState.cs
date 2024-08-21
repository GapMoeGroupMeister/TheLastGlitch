using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : EnemyState<EnemyStateEnum>
{
    public SoldierAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
