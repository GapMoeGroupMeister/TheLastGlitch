using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        //Debug.Log("Idle State");
        _player.MovementComponent._xMove = 0;
        if (_player._xMove != 0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Walk);
        }

        if (_player.MovementComponent.rbCompo.velocity.y > 0 && !_player.MovementComponent.isGround.Value)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Jump);
        }

        if (_player._isDead)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Dead);
        }
    }
}
