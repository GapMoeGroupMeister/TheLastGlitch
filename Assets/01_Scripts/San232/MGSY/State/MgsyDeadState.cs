using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyDeadState : MGSYState<BossStateEnum>
{
    public MgsyDeadState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
