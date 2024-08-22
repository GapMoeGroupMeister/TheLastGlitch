using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomWatingState : EnemyState<EnemyStateEnum>
{
    public BoomWatingState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
