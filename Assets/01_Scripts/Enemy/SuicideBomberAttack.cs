using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomberAttack : EnemyAttack
{
    private void Awake()
    {
        _playerHealth = _player.GetComponent<Health>();
    }

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }
    private void DetectAndAttack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, status.attackRadius, whatIsPlayer);

        Debug.Log(hitColliders.Length);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                Debug.Log("Pung");
                Attack();
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, status.attackRadius);
    }

    public void Attack()
    {

        if (_playerHealth != null)
        {
            _playerHealth.TakeDamage(status.attackPower);
        }

    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(status.attackSpeed);

            DetectAndAttack();
        }
    }
}
