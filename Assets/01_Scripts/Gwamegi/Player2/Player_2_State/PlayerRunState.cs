using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerRunState : PlayerState<PlayerStateEnum>
{
    public PlayerRunState(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
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
        Debug.Log("นึ Run");
        _player.MovementComponent.SetMovement(_player._xMove);

        if (_player._xMove == 0)
        {
            stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
