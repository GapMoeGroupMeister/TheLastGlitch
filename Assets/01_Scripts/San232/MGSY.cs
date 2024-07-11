using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSY : EnemySetting
{
    public StateMachine<BossStateEnum> StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<BossStateEnum>();

        StateMachine.AddState(BossStateEnum.Idle, new MgsyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(BossStateEnum.Closed, new MgsyClosedState(this, StateMachine, "Closed"));
        StateMachine.AddState(BossStateEnum.Opened, new MgsyOpenedState(this, StateMachine, "Opened"));
        StateMachine.AddState(BossStateEnum.AngryOpened, new MgsyAngryOpenedState(this, StateMachine, "AngryOpened"));
    }

    private void Start()
    {
        StateMachine.InitInitialize(BossStateEnum.Idle, this);
    }
    
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        
    }

    public override void SetDeadState()
    {

    }
}
