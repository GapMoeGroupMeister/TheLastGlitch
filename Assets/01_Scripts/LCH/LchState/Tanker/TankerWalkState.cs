using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerWalkState : EnemyState<EnemyStateEnum>
{
    StateManager stateManager;
    public TankerWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        stateManager = enemyBase as StateManager;
    }

    public override void Enter()
    {
        _enemy.MovementComponent._canMove = true;
        if (_enemy.IsDie)
        {
            _enemy.StateMachine.ChangeState(EnemyStateEnum.Dead);
        }
        base.Enter();
    }

    public override void UpdateState()
    {
        if(!_enemy.IsDie)
        {
            stateManager.EnemyMove();
            stateManager.EnemyStop();
            stateManager.EnemyFlips();
            Collider2D player = _enemy.GetPlayerRange();

            if (player != null)
            {
                _enemy.targetTrm = player.transform;
                _enemy.StateMachine.ChangeState(EnemyStateEnum.Chase);
            }
        }
        base.UpdateState();
    }
}
