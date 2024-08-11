using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        isCloser = false;
        isBoom = true;
        StateMachine.AddState(EnemyStateEnum.Idle, new EnemyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Dead, new EnemyDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Attack, new BoomAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Walk, new EnemyWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyStateEnum.Chase, new EnemyChaseState(this, StateMachine, "Chase"));
    }
}
