using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public EnemyGroundState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        
    }
    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }

}
