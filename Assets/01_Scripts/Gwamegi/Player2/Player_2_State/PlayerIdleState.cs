using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState<PlayerStateEnum>
{
    public PlayerIdleState(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementComponent.StopImmediately();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("นึ Idle");

        if (_player._xMove != 0)
        {
            stateMachine.ChangeState(PlayerStateEnum.Run);
        }
    }
}
