using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState<PlayerStateEnum>
{
    public PlayerHitState(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        _player._isHit = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_player._xMove != 0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Walk);
        }

        else if (_player._isHit)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }


    }
}
