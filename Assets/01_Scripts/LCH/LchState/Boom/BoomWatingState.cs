using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomWatingState : EnemyState<EnemyStateEnum>
{
    StateManager state;
    BoomEnemy boom;
    public BoomWatingState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        state = enemyBase as StateManager;
        boom = enemyBase as BoomEnemy;
    }
    public override void UpdateState()
    {
        if(boom._boomDealy < boom._boomWait + Time.deltaTime&& _enemy.targetTrm.position.x < _enemy.attackRadius)
        {
            _stateMachine.ChangeState(EnemyStateEnum.Dead);
        }
        else
        {
            boom._boomWait = 0f;
            _stateMachine.ChangeState(EnemyStateEnum.Walk);
        }
        base.UpdateState();
    }
}
