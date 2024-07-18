using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerCanAttackState : PlayerState<PlayerStateEnum>
{
    public PlayerCanAttackState(Player _onwer, StateMachine<PlayerStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
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

        if (_player._isAttack)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Weapon2Attack1);
        }
    }
}
