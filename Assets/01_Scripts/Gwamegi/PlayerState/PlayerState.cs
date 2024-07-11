using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState<T> : State<T> where T : Enum
{
    public PlayerState(Agent _onwer, StateMachine<T> state, string animHashName) : base(_onwer, state, animHashName)
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
