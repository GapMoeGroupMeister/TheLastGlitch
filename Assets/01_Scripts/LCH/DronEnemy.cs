using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronEnemy : Enemy
{
    public PolygonCollider2D _collider;
    [SerializeField] private ContactFilter2D _filter;
    public Collider2D GetPlayer()
    {
        int count = Physics2D.OverlapCollider(_collider, _filter, _colliders);
        return count > 0 ? _colliders[0] : null;
    }

    protected override void Awake()
    {
        base.Awake();
        isCloser = false;
        StateMachine.AddState(EnemyStateEnum.Idle, new DronIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(EnemyStateEnum.Dead, new EnemyDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(EnemyStateEnum.Attack, new DronAttackState(this, StateMachine, "Attack"));
        StateMachine.AddState(EnemyStateEnum.Walk, new DronWalkState(this, StateMachine, "Walk"));
        _colliders = new Collider2D[3];
    }

    
}
