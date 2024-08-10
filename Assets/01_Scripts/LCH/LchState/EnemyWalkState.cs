using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    Vector2 dir;

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

        _enemy.MovementComponent.SetMovement(dir.normalized.x);

        Collider2D player = _enemy.GetPlayerRange();
        Debug.Log(player + _enemy.name);

        if (player != null)
        {
            _enemy.targetTrm = player.transform;

            if (_enemy.isCloser)
            {
                _stateMachine.ChangeState(EnemyStateEnum.Chase);
                return;
            }
            else
                _stateMachine.ChangeState(EnemyStateEnum.Attack);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
