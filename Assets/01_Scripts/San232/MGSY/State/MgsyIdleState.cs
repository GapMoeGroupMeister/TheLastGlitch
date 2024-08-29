using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyIdleState : MGSYState<BossStateEnum>
{
    public MgsyIdleState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    private void DetectPlayer()
    {
        Collider2D detectedCollider = Physics2D.OverlapCircle(mgsy.transform.position, mgsy.detectRadius, mgsy._whatIsPlayer);

        if (detectedCollider != null && detectedCollider.CompareTag("Player"))
        {
            _stateMachine.ChangeState(BossStateEnum.Closed);
        }

    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        DetectPlayer();
    }

    public override void Exit()
    {
        base.Exit();
        mgsy.HealthComponent.IsHittable = false;
    }
}
