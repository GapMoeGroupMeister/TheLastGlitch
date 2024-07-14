using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public EnemyAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent.StopImmediately(false);
    }
    public override void UpdateState()
    {
        _enemy.lastAttackTime += Time.time;
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
        if(_endTriggerCalled)
        {
            _stateMachine.ChangeState(EnemyStateEnum.Chase);
        }
    }

}
