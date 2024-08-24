using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronEnemy : ADEnemy
{
    public PolygonCollider2D _collider;
    [SerializeField] private ContactFilter2D _filter;

    int count;
    public Collider2D GetPlayerDron()   
    {
        if(!IsDie)
            count = Physics2D.OverlapCollider(_collider, _filter, _colliders);

          return count > 0 ? _colliders[0] : null;
    }

    protected override void Awake()
    {
        base.Awake();

        StateMachine.AddState(EnemyStateEnum.Idle, new DronIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Attack, new DronAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Walk, new DronWalkState(this, StateMachine, "Walk"));
        StateMachine.AddState(EnemyStateEnum.Dead, new DronDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Hit, new EnemyHitState(this, StateMachine, "Hit"));

        _colliders = new Collider2D[3];
    }

    
}
