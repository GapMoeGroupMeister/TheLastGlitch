using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronWalkState : EnemyWalkState
{
    public DronEnemy _dron;
    public DronWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _dron = enemyBase as DronEnemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemy.MovementComponent.SetMovement(_dron.dir.normalized.x);

        Collider2D player = _dron.GetPlayerDron();

        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            if (!_enemy.isCloser && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
            {
                _stateMachine.ChangeState(EnemyStateEnum.Attack);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
