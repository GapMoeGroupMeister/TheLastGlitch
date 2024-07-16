using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYState<T> : State<T> where T : Enum
{
    
    public MGSYState(MGSY enemyBase, StateMachine<T> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
