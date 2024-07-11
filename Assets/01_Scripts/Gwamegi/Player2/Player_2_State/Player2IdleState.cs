using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2IdleState : State<PlayerStateEnum>
{
    public Player2IdleState(Agent _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
    {
    }



}
