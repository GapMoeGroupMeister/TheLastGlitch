using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsPlayer;
    public EnemyDataSO status;
    void Update()
    {
        DetectAndAttack();
    }

    void DetectAndAttack()
    {
        // 원형 범위 내의 모든 콜라이더 감지
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, status.attackRadius, whatIsPlayer);

        // 감지된 콜라이더 중 Player 태그를 가진 오브젝트 찾기
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                // Player 오브젝트를 공격하는 로직
                Attack(hitCollider.gameObject);
            }
        }
    }

    void Attack(GameObject player)
    {
        StartCoroutine(AttackCoolTime());
    }

    private IEnumerator AttackCoolTime()
    {
        yield return new WaitForSeconds(status.attackSpeed);
    }

}
