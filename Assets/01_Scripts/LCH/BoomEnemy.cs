using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnemy : Enemy
{
    [SerializeField] private float _boomDealy;
    protected override void Awake()
    {
        base.Awake();
       
        StateMachine.AddState(EnemyStateEnum.Hit, new EnemyHitState(this, StateMachine, "Hit"));
    }
}
