using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerDeadState : EnemyState<EnemyStateEnum>
{
    private readonly int _deadLayer = LayerMask.NameToLayer("DeadEnemy");
    public TankerDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       _enemy.gameObject.layer = _deadLayer;
        _enemy.MovementComponent._canMove = false;
        _enemy.MovementComponent._xMove = 0;
        _enemy.MovementComponent.StopImmediately();
        _enemy.SetDead(true);
    }

    public override void UpdateState()
    {
        if (_endTriggerCalled)
        {
            PlayExplosion();
        }

        base.UpdateState();
    }

    private void PlayExplosion()
    {
        _enemy.FinalDeadEvent?.Invoke();
        Ipoolable ipoolable = _enemy.GetComponent<Ipoolable>();
        if (ipoolable != null)
        {
            PoolManager.Instance.Push(ipoolable);
        }
        else
        {
            GameObject.Destroy(_enemy.gameObject);
        }
    }
}
