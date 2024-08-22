using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomWatingState : EnemyState<EnemyStateEnum>
{
    StateManager state;
    BoomEnemy boom;
    float _boomDelay;
    public BoomWatingState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        state = enemyBase as StateManager;
        boom = enemyBase as BoomEnemy;
    }

    public override void Enter()
    {
        _enemy.MovementComponent._canMove = false;
        base.Enter();
    }

    public override void UpdateState()
    {
        _boomDelay += boom._boomWait + Time.deltaTime;
        if (boom._boomDealy < _boomDelay && _enemy.targetTrm.position.x < _enemy.attackRadius)
        { 
            _stateMachine.ChangeState(EnemyStateEnum.Dead);
        }
        else if( _enemy.transform.position.x > _enemy.attackRadius)
        {
            _boomDelay = 0f;
            _enemy.MovementComponent._canMove = true;
            _stateMachine.ChangeState(EnemyStateEnum.Idle);
        }
        base.UpdateState();
    }
}
