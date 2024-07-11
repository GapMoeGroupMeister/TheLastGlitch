using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSY : Agent
{
    public StateMachine<BossStateEnum> StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<BossStateEnum>();

        StateMachine.AddState(BossStateEnum.Idle, new MgsyIdleState(this, StateMachine, "Idle"));
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
