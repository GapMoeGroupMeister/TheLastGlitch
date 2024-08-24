using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerEnemy : StateManager ,Ipoolable
{
    public string PoolName => poolName;

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        StateMachine.AddState(EnemyStateEnum.Idle, new TankerIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Walk, new TankerWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyStateEnum.Chase, new TankerChaseState(this, StateMachine, "Chase"));
        StateMachine.AddState(EnemyStateEnum.Attack, new TankerAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Dead, new TankerDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Hit, new EnemyHitState(this, StateMachine, "Hit"));
    }
}
