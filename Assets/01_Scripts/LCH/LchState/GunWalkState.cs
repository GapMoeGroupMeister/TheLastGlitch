using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunWalkState : EnemyState<EnemyStateEnum>
{
    GunEnemy _gun;
    public GunWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _gun = enemyBase as GunEnemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _enemy.MovementComponent.SetMovement(_gun.dir.normalized.x);

        Collider2D player = _gun.ThisIsPlayer();

        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            if (!_enemy.isCloser && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
            {
                _stateMachine.ChangeState(EnemyStateEnum.Attack);
            }
        }
    }
}
