using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    Vector2 dir;

    public EnemyWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.StartCoroutine(Delaytime());
    }

    private IEnumerator Delaytime()
    {
        dir = _enemy.GetRandomVector() - _enemy.transform.position;
        yield return new WaitForSeconds(2f);
        _stateMachine.ChangeState(EnemyStateEnum.Idle);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemy.MovementComponent.SetMovement(dir.normalized.x);

        Collider2D player = _enemy.GetPlayerRange();

        if (player != null)
        {
            _enemy.targetTrm = player.transform;

            if (_enemy.isMelee)
            {
                if(_enemy.isCloser)
                {
                    _stateMachine.ChangeState(EnemyStateEnum.Chase);
                    return;
                }
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
