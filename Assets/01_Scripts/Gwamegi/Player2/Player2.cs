using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    public StateMachine<PlayerStateEnum> _stateMachine;


    protected override void Awake()
    {
        base.Awake();

        _stateMachine = new StateMachine<PlayerStateEnum>();

        _stateMachine.AddState(PlayerStateEnum.Idle, new PlayerIdleState(this, _stateMachine,"Idle"));
        _stateMachine.AddState(PlayerStateEnum.Walk, new PlayerWalkState(this, _stateMachine, "Walk"));
        _stateMachine.AddState(PlayerStateEnum.Jump, new PlayerJumpState(this, _stateMachine, "Jump"));
        _stateMachine.AddState(PlayerStateEnum.Fall, new PlayerFallState(this, _stateMachine, "Fall"));
        _stateMachine.AddState(PlayerStateEnum.Weapon2Attack1, new PlayerWeapon2Attack1State(this, _stateMachine, "Weapon2Attack1"));
        _stateMachine.AddState(PlayerStateEnum.Weapon2Attack2, new PlayerWeapon2Attack2State(this, _stateMachine, "Weapon2Attack2"));

        _stateMachine.InitInitialize(PlayerStateEnum.Idle,this);
    }

    protected override void Update()
    {
        base.Update();
        _stateMachine.CurrentState.UpdateState();
    }

    




}
