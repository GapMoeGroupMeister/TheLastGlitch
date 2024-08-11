using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon1Attack1State : PlayerState<PlayerStateEnum>
{
    public PlayerWeapon1Attack1State(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
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
