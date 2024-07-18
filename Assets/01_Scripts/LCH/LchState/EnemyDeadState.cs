using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState<EnemyStateEnum>
{
    private Enemy _enemy;
    private bool _onExplosion = false;
    public EnemyDeadState(Enemy enemyBase, StateMachine<EnemyStateEnum> state, string animHashName) : base(enemyBase, state, animHashName)
    {
        _enemy = enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
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
        if (_endTriggerCalled && !_onExplosion)
        {
            _onExplosion = true;
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
