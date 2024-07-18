using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerWeapon2Attack1State : PlayerState<PlayerStateEnum>
{
    public PlayerWeapon2Attack1State(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.Attack1Disable();
        Debug.Log("Attack1 anim");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_player._isAttack)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }

        else if (_player._isDoubleAttack)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Weapon2Attack2);
        }
    }
}
