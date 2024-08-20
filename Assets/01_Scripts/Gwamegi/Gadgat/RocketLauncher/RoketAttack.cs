using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoketAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackknockbackPower;
    [SerializeField] private LayerMask _enemyLayer;

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position, _attackRange, _enemyLayer);

        if (enemy.Length <= 0) return;
        Debug.Log("실행되었음");

        foreach (Collider2D item in enemy)
        {
            item.GetComponent<Health>().TakeDamage(_attackDamage, item.transform.position.normalized, _attackknockbackPower);
        }
    }

}
