using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomChaseState : EnemyState<EnemyStateEnum>
{
    public BoomChaseState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
      
            Vector2 dir = _enemy.targetTrm.position - _enemy.transform.position;
            _enemy.distance = dir.magnitude;
            _enemy.HandleSpriteFlip(_enemy.targetTrm.position);
            _enemy.MovementComponent.SetMovement(dir.normalized.x);

            if (_enemy.distance > _enemy.detectRadius + 3f || _enemy.fainting == true )
            {
                _stateMachine.ChangeState(EnemyStateEnum.Idle);
                return;
            }

            if (_enemy.distance < _enemy.attackRadius)
            {
                if (_enemy.CanAttack)
                    _stateMachine.ChangeState(EnemyStateEnum.Wait);
            }
        base.UpdateState();
    }
}
