using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronEnemy : Enemy
{
    public PolygonCollider2D _collider;
    [SerializeField] private ContactFilter2D _filter;

    private void Update()
    {
        Physics2D.OverlapCollider(_collider, _filter, _colliders);
    }

    protected override void Awake()
    {
        base.Awake();
        StateMachine.AddState(EnemyStateEnum.Idle, new EnemyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Chase, new EnemyChaseState(this, StateMachine, "Chase"));
        StateMachine.AddState(EnemyStateEnum.Dead, new EnemyDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Attack, new DronAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Walk, new EnemyWalkState(this, StateMachine, "Walk"));
    }
}
