using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnemy : Enemy
{
    [SerializeField] private float _boomDealy;
    protected override void Awake()
    {
        base.Awake();
       
        StateMachine.AddState(EnemyStateEnum.Hit, new EnemyHitState(this, StateMachine, "Hit"));
        StateMachine.AddState(EnemyStateEnum.Idle, new BoomIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Chase, new BoomChaseState(this, StateMachine, "Chase"));
        StateMachine.AddState(EnemyStateEnum.Dead, new BoomDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Walk, new BoomWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyStateEnum.Wait, new BoomWatingState(this, StateMachine, "Wait"));
    }
}
