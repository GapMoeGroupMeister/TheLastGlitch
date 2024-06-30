using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState<T> where T : class
{
    public virtual void UpdateState(T state)
    {

    }

    public virtual void Enter(T state)
    {

    }
    public virtual void Exit(T state)
    {

    }
}
