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
        _walkCoroutine = _enemy.StartCoroutine(ChangeToWalk());
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
