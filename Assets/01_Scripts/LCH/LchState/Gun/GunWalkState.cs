using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunWalkState : EnemyState<EnemyStateEnum>
{
    GunEnemy _gun;
    StateManager state;
    public GunWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _gun = enemyBase as GunEnemy;
        state = enemyBase as StateManager;
    }

    public override void Enter()
    {
        _enemy.MovementComponent._canMove = true;
        if (_enemy.IsDie)
        {
            _enemy.StateMachine.ChangeState(EnemyStateEnum.Dead);
        }
        base.Enter();
    }

    public override void UpdateState()
    {
      
            state.EnemyMove();
            state.EnemyStop();
            state.EnemyFlips();

            Collider2D player = _gun.ThisIsPlayer();

            if (player != null)
            {
                _enemy.targetTrm = player.transform;
                if (_enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
                {
                    _stateMachine.ChangeState(EnemyStateEnum.Attack);
                }
            }
        base.UpdateState();

    }
}
