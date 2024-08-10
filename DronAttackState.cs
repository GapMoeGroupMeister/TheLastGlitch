using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAttackState : EnemyAttackState
{
    public DronAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
    }
}