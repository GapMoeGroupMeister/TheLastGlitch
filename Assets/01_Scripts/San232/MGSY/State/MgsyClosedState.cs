using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyClosedState : MGSYState<BossStateEnum>
{
    public Action OnClosedEnter;


    public MgsyClosedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        health.IsHittable = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
    }
}
