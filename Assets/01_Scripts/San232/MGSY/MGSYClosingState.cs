using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYClosingState : State<BossStateEnum>
{
    public MGSYClosingState(Agent _onwer, StateMachine<BossStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
    {

    }
}