using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAttackState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public BoomAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent._canMove = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        if (_endTriggerCalled)
        {
            _enemy.lastAttackTime = Time.time;
            if (_enemy.isCloser)
                _stateMachine.ChangeState(EnemyStateEnum.Chase);
            else if (_enemy.isBoom)
                _enemy.HealthComponent.OnDeadEvent?.Invoke();

            _enemy.MovementComponent._canMove = true;
        }
        base.UpdateState();
    }
}
