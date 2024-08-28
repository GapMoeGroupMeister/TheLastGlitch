using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEndTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private ADEnemy _ad;

    public void AnimationEnd()
    {
        Debug.Log("AnimationEnd");
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

    public void DeadTrigger()
    {
        Vector2 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        int index = Random.Range(0, _enemy.DeadItem.Length);
        GameObject.Instantiate(_enemy.DeadItem[index],pos, Quaternion.identity);
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
