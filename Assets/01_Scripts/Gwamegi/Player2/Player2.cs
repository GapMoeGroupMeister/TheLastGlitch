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

        _stateMachine.AddState(PlayerStateEnum.Idle,new PlayerIdleState(this,_stateMachine,"Idle"));
        _stateMachine.AddState(PlayerStateEnum.Run,new PlayerRunState(this,_stateMachine,"Run"));

        _stateMachine.InitInitialize(PlayerStateEnum.Idle,this);
    }

    protected override void Update()
    {
        base.Update();
        _stateMachine.CurrentState.UpdateState();
    }

    




}
