using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYClosingState : MGSYState<BossStateEnum>
{
    public MGSYClosingState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        mgsy.HealthComponent.IsHittable = false;
    }
}