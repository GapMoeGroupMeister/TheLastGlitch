using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronChaseState : EnemyState<EnemyStateEnum>
{
    public DronChaseState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
