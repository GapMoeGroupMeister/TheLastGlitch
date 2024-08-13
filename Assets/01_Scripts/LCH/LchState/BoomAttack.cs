using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAttack : EnemyState<EnemyStateEnum>

{
    public BoomAttack(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
}
