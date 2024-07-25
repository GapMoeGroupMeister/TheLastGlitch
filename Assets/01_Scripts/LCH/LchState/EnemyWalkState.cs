using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;

    public EnemyWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void UpdateState()
    {
        base.UpdateState();
        Vector2 dir = _enemy.GetRandomVector() - _enemy.transform.position;

        _enemy.MovementComponent.SetMovement(Mathf.Sign(dir.x));

        Collider2D player = _enemy.GetPlayerRange();

        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            _stateMachine.ChangeState(EnemyStateEnum.Chase);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
