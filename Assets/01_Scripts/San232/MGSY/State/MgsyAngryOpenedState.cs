using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyAngryOpenedState : MGSYState<BossStateEnum>
{
    public MgsyAngryOpenedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        
    }

}
