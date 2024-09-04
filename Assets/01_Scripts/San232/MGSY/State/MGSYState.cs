using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYState<T> : State<T> where T : Enum
{
    [SerializeField] protected MGSY mgsy;

    public MGSYState(MGSY enemyBase, StateMachine<T> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        mgsy = enemyBase;
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
