using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyOpenedState : EnemyState<BossStateEnum>
{
    public MgsyOpenedState(Agent enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }
}
