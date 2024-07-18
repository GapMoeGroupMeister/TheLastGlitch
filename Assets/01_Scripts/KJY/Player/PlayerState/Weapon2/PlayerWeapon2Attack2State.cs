using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon2Attack2State : PlayerState<PlayerStateEnum>
{
    public PlayerWeapon2Attack2State(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Attack2 anim");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        //Debug.Log("Attack1 anim");
        if (!_player._isDoubleAttack)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }

        else if (_player._isDoubleAttack)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Weapon2Attack2);
        }
    }
}
