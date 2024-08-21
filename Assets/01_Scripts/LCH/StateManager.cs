using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Enemy
{
    public void WalkChanges()
    {
        StartCoroutine(ChangeToWalk());
    }

    public void CloserAttackEnter()
    {
        MovementComponent._canMove = false;
        FirstAttack = false;
    }

    public void EnemyMove()
    {
        MovementComponent.SetMovement(dir.normalized.x);
    }

    public void EnemyAttack()
    {
        lastAttackTime = Time.time;
        StateMachine.ChangeState(EnemyStateEnum.Chase);
        MovementComponent._canMove = true;
    }

    public void EnemyStop()
    {
        if (MovementComponent._xMove == 0)
        {
            StateMachine.ChangeState(EnemyStateEnum.Idle);
        }
    }

    private IEnumerator ChangeToWalk()
    {
        yield return new WaitForSeconds(2f);
        StateMachine.ChangeState(EnemyStateEnum.Walk);
    }
}
