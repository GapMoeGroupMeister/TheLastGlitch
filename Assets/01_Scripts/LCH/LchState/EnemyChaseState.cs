using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public EnemyChaseState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector2 dir = _enemy.targetTrm.position - _enemy.transform.position;
        float distance = dir.magnitude;

        if(distance > _enemy.detectRadius + 3f)
        {
            _stateMachine.ChangeState(EnemyStateEnum.Idle);
            return;
        }

        _enemy.MovementComponent.SetMovement(dir.normalized.x);

        if(distance < _enemy.attackRadius && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            _stateMachine.ChangeState(EnemyStateEnum.Attack);
            return;
        }
    }
}
