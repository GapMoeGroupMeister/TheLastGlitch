using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimEndTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ADEnemy _ad;
    public UnityEvent SfxEvent;

    public void AnimationEnd()
    {
        _enemy.AnimationEndTrigger();
    }
    
    public void AnimationAttackTrigger()
    {
        _enemy.Attack();
    }

    public void SfxTrigger()
    {
        SfxEvent?.Invoke();
    }

    public void AnimationLaserAttackTrigger()
    {
        _ad.LaserAttack();
    }

    public void DeadTrigger()
    {
        int index = Random.Range(0, _enemy.DeadItem.Length);
        GameObject.Instantiate(_enemy.DeadItem[index],_enemy.transform.position, Quaternion.identity);
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
