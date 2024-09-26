using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYShootingState : MGSYState<BossStateEnum>
{
    public MGSYShootingState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
    
