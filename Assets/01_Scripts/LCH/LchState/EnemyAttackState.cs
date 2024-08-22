using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;

    public EnemyAttackState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementComponent._canMove = false;
        _enemy.FirstAttack = false;
    }
    public override void UpdateState()
    {

        if (_endTriggerCalled)
        {
            _enemy.lastAttackTime = Time.time;
            if (_enemy.isCloser)
                _stateMachine.ChangeState(EnemyStateEnum.Chase);
            else if (_enemy.isBoom)
                _stateMachine.ChangeState(EnemyStateEnum.Attack);

            _enemy.MovementComponent._canMove = true;
        }                                                                                                                                                                                                                                                                                                                                                                                                               

        base.UpdateState();
    }

}
