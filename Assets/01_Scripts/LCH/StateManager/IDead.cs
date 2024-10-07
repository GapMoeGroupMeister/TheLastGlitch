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
        _enemy.SetDead(true);
        _enemy.gameObject.layer = _deadLayer;
        _enemy.MovementComponent._canMove = false;
        _enemy.MovementComponent._xMove = 0;
        _enemy.MovementComponent.StopImmediately();
        _enemy.gameObject.tag = "DeadEnemyTag";
    }


    public void PlayExplosion()
    {
        if (_enemy.IsDie)
        {
                GameObject.Destroy(_enemy.gameObject);
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
