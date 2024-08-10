using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronWalkState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    public DronEnemy _dron;
    public DronWalkState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        _enemy = enemyBase;
        _dron = _enemy as DronEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.StartCoroutine(Delaytime());
    }

    private IEnumerator Delaytime()
    {
        _dron.dir = _enemy.GetRandomVector() - _enemy.transform.position;
        yield return new WaitForSeconds(2f);
        _stateMachine.ChangeState(EnemyStateEnum.Idle);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemy.MovementComponent.SetMovement(_dron.dir.normalized.x);

        Collider2D player = _dron.GetPlayer();

        if (player != null)
        {
            _enemy.targetTrm = player.transform;
            if (_enemy.isMelee)
            {
                if (!_enemy.isCloser)
                {
                    _stateMachine.ChangeState(EnemyStateEnum.Attack);
                }
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
