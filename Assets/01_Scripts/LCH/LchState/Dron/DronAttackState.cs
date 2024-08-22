using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAttackState : EnemyState<EnemyStateEnum>
{ 
    public DronAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
      if(!_enemy.IsDie)
        {
            _enemy.MovementComponent._canMove = false;
            _enemy.MovementComponent.StopImmediately();
            _enemy.FirstAttack = false;
        }
    }

    public override void UpdateState()
    {
        if (!_enemy.IsDie)
        {
            if (_endTriggerCalled)
            {
                _enemy.lastAttackTime = Time.time;

                _enemy.MovementComponent._canMove = true;
                _stateMachine.ChangeState(EnemyStateEnum.Walk);
            }
        }
        base.UpdateState();
    }
}
