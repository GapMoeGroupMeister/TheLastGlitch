using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DeadInt : EnemyState<EnemyStateEnum>
{
    Pooling _enemyPush;
    public DeadInt(Enemy enemyBase, StateMachine<EnemyStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }
    private readonly int _deadLayer = LayerMask.NameToLayer("DeadEnemy");
    public void DeadEnter()
    {
        _enemy.gameObject.layer = _deadLayer;
        _enemy.MovementComponent._canMove = false;
        _enemy.MovementComponent._xMove = 0;
        _enemy.MovementComponent.StopImmediately();
        _enemy.SetDead(true);
        _enemy.gameObject.tag = "Untagged";
       _enemyPush = _enemy._enemyPooling = _enemy.GetComponent<Pooling>();
    }


    public void PlayExplosion()
    {
        if (_enemy.IsDie)
        {
            _enemy.FinalDeadEvent?.Invoke();
            Ipoolable ipoolable = _enemyPush.GetComponent<Ipoolable>();
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

    public void EnemyPush()
    {
        Ipoolable ipoolable = _enemyPush.GetComponent<Ipoolable>();
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
