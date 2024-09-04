using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyIdleState : MGSYState<BossStateEnum>
{
    public MgsyIdleState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    private void Change2Closed()
    {
        
        _stateMachine.ChangeState(BossStateEnum.Closed);
        
    }


    public override void Enter()
    {
        base.Enter();
        mgsy.HealthComponent.IsHittable = false;
        Change2Closed();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
