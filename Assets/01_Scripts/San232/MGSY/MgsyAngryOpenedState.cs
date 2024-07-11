using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyAngryOpenedState : EnemyState<BossStateEnum>
{
    public MgsyAngryOpenedState(Agent enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

}
