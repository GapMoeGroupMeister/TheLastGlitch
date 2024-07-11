using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyClosedState : EnemyState<BossStateEnum>
{
    public MgsyClosedState(Agent enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

}
