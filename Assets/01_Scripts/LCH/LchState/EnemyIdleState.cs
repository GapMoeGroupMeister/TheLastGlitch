using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public EnemyIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent.StopImmediately(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Collider2D player = _enemy.GetPlayerRange();
        if(player != null)
        {
            _enemy.targetTrm = player.transform;
            _stateMachine.ChangeState(EnemyStateEnum.Chase);
        }
    }
}
