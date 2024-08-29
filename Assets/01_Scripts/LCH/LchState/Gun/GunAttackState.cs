using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackState : EnemyState<EnemyStateEnum>
{
    GunEnemy _gun;
    public GunAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _gun = enemyBase as GunEnemy;
    }

    public override void Enter()
    {
        _enemy.MovementComponent._canMove = false;
        _enemy.MovementComponent.StopImmediately();
        _enemy.FirstAttack = false;
        _enemy.HandleSpriteFlip(_enemy.targetTrm.position);
        base.Enter();
    }
    public override void UpdateState()
    {
        if (_endTriggerCalled)
        {
            _enemy.lastAttackTime = Time.time;
         
                _enemy.MovementComponent._canMove = true;
                _stateMachine.ChangeState(EnemyStateEnum.Walk);
        }
        base.UpdateState();
    }
}
