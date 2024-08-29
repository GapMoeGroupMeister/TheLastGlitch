using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerWalkState : PlayerCanAttackState
{
    public PlayerWalkState(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
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

        _player.MovementComponent.SetMovement(_player._xMove);
        //Debug.Log("Walk State");
        if (_player._xMove == 0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }

        if (!_player.MovementComponent.isGround.Value)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Jump);
        }

        if (_player._isHit)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Hit);
        }

        if (_player._isDead)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Dead);
        }
    }
}

