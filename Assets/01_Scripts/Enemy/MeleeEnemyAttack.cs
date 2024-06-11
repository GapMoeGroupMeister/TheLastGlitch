using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameObject _player;
    public EnemyDataSO status;

    private void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    private void Awake()
    {
        _playerHealth = _player.GetComponent<Health>();
    }

    private void DetectAndAttack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, status.attackRadius, whatIsPlayer);

        Debug.Log(hitColliders.Length);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                Debug.Log("TatsuKete");
                Attack();
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
