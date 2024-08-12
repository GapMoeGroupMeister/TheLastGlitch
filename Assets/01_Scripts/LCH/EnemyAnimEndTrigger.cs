using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEndTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public void AnimationEnd()
    {
        _enemy.AnimationEndTrigger();
    }
    
    public void AnimationAttackTrigger()
    {
        _enemy.Attack();
        Debug.Log("attack");
    }

    public void AnimationLaserAttackTrigger()
    {
        _enemy.LaserAttack();
        Debug.Log("attack");
    }
}
