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
            if(!_enemy.IsDie)
            {

                 boom._boomWait += Time.deltaTime;
                if (boom._boomDealy < boom._boomWait && _enemy.targetTrm.position.x < _enemy.attackRadius)
                { 
                    _stateMachine.ChangeState(EnemyStateEnum.Dead);
                }
                if(!boom.ThisIsPlayer())
                {
                    boom._boomWait= 0f;
                    _enemy.MovementComponent._canMove = true;
                    _stateMachine.ChangeState(EnemyStateEnum.Walk);
            }
            base.UpdateState();
        }
    }
}
