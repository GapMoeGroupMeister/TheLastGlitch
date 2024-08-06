using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyIdleState : MGSYState<BossStateEnum>
{
    

    public MgsyIdleState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        health.IsHittable = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Collider2D player = mgsy.GetPlayerInRange();
        if(player != null)
        {
            mgsy.targetTrm = player.transform;
            _stateMachine.ChangeState(BossStateEnum.Closed);
        }
    }
}
