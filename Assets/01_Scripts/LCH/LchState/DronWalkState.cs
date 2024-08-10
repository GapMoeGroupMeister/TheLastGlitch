using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronWalkState : EnemyWalkState
{
    private Enemy _enemy;
    public DronEnemy _dron;
    public DronWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _enemy = enemyBase;
        _dron = _enemy as DronEnemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    

    public override void UpdateState()
    {
        base.UpdateState();

        _enemy.MovementComponent.SetMovement(_dron.dir.normalized.x);

        Collider2D player = _dron.GetPlayer();

        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            if (!_enemy.isCloser)
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
