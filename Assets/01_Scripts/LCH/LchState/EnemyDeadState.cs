using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState<EnemyStateEnum>
{
    private readonly int _deadLayer = LayerMask.NameToLayer("DeadEnemy");
    private bool _onExplosion = false;
    public EnemyDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.gameObject.layer = _deadLayer;
        _enemy.MovementComponent._canMove = false;
        _enemy.MovementComponent._xMove = 0;
        _enemy.MovementComponent.StopImmediately();
        _enemy.SetDead(true);
        _onExplosion = false;
    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            // Dead
            //UnityEngine.Object.Destroy(_enemy.gameObject);
            PlayExplosion();
        }
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
