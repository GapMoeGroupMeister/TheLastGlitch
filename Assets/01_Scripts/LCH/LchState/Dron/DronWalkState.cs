using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronWalkState : EnemyState<EnemyStateEnum>
{
    public DronEnemy _dron;
    private StateManager state;

    public DronWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _dron = enemyBase as DronEnemy;
        state = enemyBase as StateManager;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent._canMove = true;
    }

    public override void UpdateState()
    {
        if(!_enemy.IsDie)
        {
            state.EnemyMove();
            state.EnemyStop();
            state.EnemyFlips();

            Collider2D player = _dron.GetPlayerDron();

            if (player != null)
            {
                _enemy.targetTrm = player.transform;
                if (_enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
                {
                    _stateMachine.ChangeState(EnemyStateEnum.Attack);
                }
            }
        }
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
