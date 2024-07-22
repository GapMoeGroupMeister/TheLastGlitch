using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public EnemyIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent.StopImmediately(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector2 dir = _enemy.targetTrm.position - _enemy.transform.position;
        float distance = dir.magnitude;
        Collider2D player = _enemy.GetPlayerRange();
        if(player != null)
        {
            _enemy.targetTrm = player.transform;
            _stateMachine.ChangeState(EnemyStateEnum.Chase);
        }

        if (distance < _enemy.attackRadius && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            Debug.Log("c->a");
            _stateMachine.ChangeState(EnemyStateEnum.Attack);
            return;
        }
    }
}
