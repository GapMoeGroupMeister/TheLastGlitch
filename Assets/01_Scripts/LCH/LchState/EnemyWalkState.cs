using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;

    public EnemyWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemy.MovementComponent.SetMovement(_enemy.dir.normalized.x);

        Collider2D player = _enemy.GetPlayerRange();

        if (player != null)
        {
            _enemy.targetTrm = player.transform;

            if (_enemy.isCloser || _enemy.isBoom)
            {
                _stateMachine.ChangeState(EnemyStateEnum.Chase);
                return;
            }
            else
                _stateMachine.ChangeState(EnemyStateEnum.Attack);
        }

        if(_enemy.MovementComponent._xMove == 0)
        {
            _stateMachine.ChangeState(EnemyStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
