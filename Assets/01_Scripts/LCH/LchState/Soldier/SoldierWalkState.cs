using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWalkState : EnemyState<EnemyStateEnum>
{
    StateManager state;
    public SoldierWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        state = enemyBase as StateManager;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent._canMove = true;
    }

    public override void UpdateState()
    {
        if(!_enemy.IsDie)
        {
            state.EnemyMove();
            state.EnemyStop();
            state.EnemyFlips();
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
