using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAttackState : EnemyState<EnemyStateEnum>
{
    public BoomAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        _stateMachine.ChangeState(EnemyStateEnum.Wait);
        base.Enter();
    }
}
