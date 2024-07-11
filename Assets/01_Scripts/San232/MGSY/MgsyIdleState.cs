using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyIdleState : EnemyState<BossStateEnum>
{
    public MgsyIdleState(Agent enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
