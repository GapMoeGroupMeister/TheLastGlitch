using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpState : PlayerState<PlayerStateEnum>
{
    public PlayerJumpState(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
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
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
            
        }
    }
}
    
