using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyOpenedState : MGSYState<BossStateEnum>
{

    public MgsyOpenedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
         
    }

    public override void Enter()
    {
        base.Enter();
        mgsy.OpenedPatterns[0]?.Invoke();
    }
}
