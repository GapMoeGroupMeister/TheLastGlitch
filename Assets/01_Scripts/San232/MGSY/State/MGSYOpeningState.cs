using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYOpeningState : MGSYState<BossStateEnum>
{
    public MGSYOpeningState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
        mgsy.HealthComponent.IsHittable = true;
    }

    public void Change2OpenedState()
    {
        _stateMachine.ChangeState(BossStateEnum.Opened);
    }
}
