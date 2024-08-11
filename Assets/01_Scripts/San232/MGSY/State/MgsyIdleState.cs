using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyIdleState : MGSYState<BossStateEnum>
{
    [SerializeField] private LayerMask detectionLayer;

    public MgsyIdleState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    private void DetectPlayer()
    {
        Collider2D detectedCollider = Physics2D.OverlapCircle(mgsy.transform.position, _detectionRadius, detectionLayer);

        if (detectedCollider != null && detectedCollider.CompareTag("Player"))
        {
            mgsy.state = "Closed";
        }

    }


    public override void Enter()
    {
        base.Enter();
        health.IsHittable = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        DetectPlayer();
    }
}
