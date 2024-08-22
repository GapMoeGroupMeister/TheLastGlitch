using System;
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
       _enemy.distance = dir.magnitude;

        if (_enemy.GetPlayer() == false)
        {
            _enemy.MovementComponent._canMove = true;
        }
        else
        {
            _enemy.MovementComponent._canMove = false;
            _stateMachine.ChangeState(EnemyStateEnum.Idle);
        }
   
        if(_enemy.distance > _enemy.detectRadius + 3f)
        {
            _stateMachine.ChangeState(EnemyStateEnum.Idle);
            return;
        }

        _enemy.MovementComponent.SetMovement(dir.normalized.x);

        if (_enemy.FirstAttack&&!_enemy.isBoom)
        {
            _stateMachine.ChangeState(EnemyStateEnum.Attack);
        }

        if(_enemy.distance < _enemy.attackRadius && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time&&!_enemy.isBoom)
        {
            if(_enemy.CanAttack)
            _stateMachine.ChangeState(EnemyStateEnum.Attack);
            return;
        }

        if(_enemy.distance < _enemy.attackRadius&&_enemy.isBoom)
        {  
            if (_enemy.CanAttack)
            {
                if(_enemy.distance > _enemy.attackRadius)
                {
                    _enemy.Boom = false;
                    _enemy.StateMachine.ChangeState(EnemyStateEnum.Idle);
                }
                else
                {
                    _enemy.Boom = true;
                    _enemy.StateMachine.ChangeState(EnemyStateEnum.Idle);
                }
            }
        }
    }
}
