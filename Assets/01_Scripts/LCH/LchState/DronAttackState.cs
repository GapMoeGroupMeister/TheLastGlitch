using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAttackState : EnemyAttackState
{
    public DronAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent._canMove = false;
        _enemy.MovementComponent.StopImmediately();
        _enemy.FirstAttack = false;
    }

    public override void UpdateState()
    {

        if (_endTriggerCalled)
        {
            _enemy.lastAttackTime = Time.time;
            if (!_enemy.isCloser)
            {
                _enemy.MovementComponent._canMove = true;
              _stateMachine.ChangeState(EnemyStateEnum.Walk);
                return;
               
            }
            _stateMachine.ChangeState(EnemyStateEnum.Chase);
        }
        base.UpdateState();
    }
}
