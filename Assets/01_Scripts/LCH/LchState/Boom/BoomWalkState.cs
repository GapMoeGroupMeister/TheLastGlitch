using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomWalkState : EnemyState<EnemyStateEnum>
{
    public BoomWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
