using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        StateMachine.AddState(EnemyStateEnum.Idle, new EnemyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Chase, new EnemyChaseState(this, StateMachine, "Chase"));
        StateMachine.AddState(EnemyStateEnum.Dead, new EnemyDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Attack, new EnemyAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Walk, new EnemyWalkState(this, StateMachine, "Walk"));
    }
}
