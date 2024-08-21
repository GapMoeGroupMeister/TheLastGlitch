using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : ADEnemy
{
    public Collider2D ThisIsPlayer()
    {
        int cut = Physics2D.OverlapCircleNonAlloc(transform.position, attackRadius, _colliders, _whatIsPlayer);
        return cut > 0 ? _colliders[0] : null;
    }

    protected override void Awake()
    {
        base.Awake();

        StateMachine.AddState(EnemyStateEnum.Idle, new GunIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Attack, new GunAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Dead, new GunDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Walk, new GunWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyStateEnum.Hit, new EnemyHitState(this, StateMachine, "Hit"));
    }
}
