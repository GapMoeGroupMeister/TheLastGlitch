using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State<EnemyStateEnum>
{
    public EnemyIdleState(Agent _onwer, StateMachine<EnemyStateEnum> state, string animHashName) : base(_onwer, state, animHashName)
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
    }
}
