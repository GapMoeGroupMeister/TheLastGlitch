using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyState<EnemyStateEnum>
{
    public EnemyHitState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
            _enemy.MovementComponent._xMove = 0f;
            _enemy.MovementComponent._canMove = false;
            _enemy.MovementComponent.StopImmediately(true);
        base.Enter();
    }
    public override void UpdateState()
    {
        if (_endTriggerCalled )
        {
            _stateMachine.ChangeState(EnemyStateEnum.Walk);
        }
        base.UpdateState();
    }
}
