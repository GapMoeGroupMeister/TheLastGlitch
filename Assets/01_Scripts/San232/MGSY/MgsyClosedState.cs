using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyClosedState : MGSYState<BossStateEnum>
{
    public MgsyClosedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

}
