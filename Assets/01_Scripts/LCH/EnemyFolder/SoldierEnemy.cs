using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnemy : StateManager , Ipoolable
{
    public string PoolName => poolName;

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
      
    }

    protected override void Awake()
    {
        base.Awake();
        StateMachine.AddState(EnemyStateEnum.Idle, new SoldierIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Walk, new SoldierWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyStateEnum.Chase, new SoldierChaseState(this, StateMachine, "Chase"));
        StateMachine.AddState(EnemyStateEnum.Attack, new SoldierAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Dead, new SoldierDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Hit, new EnemyHitState(this, StateMachine, "Hit"));
    }
}
