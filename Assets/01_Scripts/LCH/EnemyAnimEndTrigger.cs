using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEndTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ADEnemy _ad;

    public void AnimationEnd()
    {
        _enemy.AnimationEndTrigger();
    }
    
    public void AnimationAttackTrigger()
    {
        Debug.Log("attack");
        _enemy.Attack();
    }

    public void AnimationLaserAttackTrigger()
    {
        Debug.Log("attack");
        _ad.LaserAttack();
    }
}
