using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState<PlayerStateEnum>
{
    public PlayerFallState(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
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
        if (_player.MovementComponent.isGround.Value)
        {
            _player._xMove = 0;
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
