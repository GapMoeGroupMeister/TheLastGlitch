using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState<EnemyStateEnum>
{
    private Coroutine _walkCoroutine;
    public EnemyIdleState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent.StopImmediately(false);
        if (_enemy.Boom)
        {
            _enemy.StartCoroutine(BoomDealay());
        }
        _walkCoroutine = _enemy.StartCoroutine(ChangeToWalk());
    }

    private IEnumerator BoomDealay()
    {
             _enemy.MovementComponent.moveSpeed = 0f;
             yield return new WaitForSeconds(1f);
             _enemy.StateMachine.ChangeState(EnemyStateEnum.Dead);

    }

    private IEnumerator ChangeToWalk()
    {
        yield return new WaitForSeconds(2f);
        _stateMachine.ChangeState(EnemyStateEnum.Walk);
    }

    public override void Exit()
    {
        _enemy.StopCoroutine(_walkCoroutine);
        base.Exit();
    }
}
