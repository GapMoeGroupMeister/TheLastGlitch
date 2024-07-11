using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public EnemyChaseState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
