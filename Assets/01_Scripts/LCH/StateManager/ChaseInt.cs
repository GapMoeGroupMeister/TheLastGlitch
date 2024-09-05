using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChaseInt : EnemyState<EnemyStateEnum>
{

    StateManager state;

    protected ChaseInt(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemyBase = state as StateManager;
    }

    public void ChaseUpdate()
    {
        Vector2 dir = _enemy.targetTrm.position - _enemy.transform.position;
        _enemy.distance = dir.magnitude;
        _enemy.HandleSpriteFlip(_enemy.targetTrm.position);
        _enemy.MovementComponent.SetMovement(dir.normalized.x);

        if (_enemy.fainting == true)
        {
            Debug.Log("Idle»óÅÂ");
            _stateMachine.ChangeState(EnemyStateEnum.Idle);
            return;
        }

        if (_enemy.FirstAttack && _enemy.distance < _enemy.attackRadius)
        { 
            if (_enemy.CanAttack)
                _stateMachine.ChangeState(EnemyStateEnum.Attack);
        }

        if (_enemy.distance < _enemy.attackRadius && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            if (_enemy.CanAttack)
                _stateMachine.ChangeState(EnemyStateEnum.Attack);
        }

    }
}
