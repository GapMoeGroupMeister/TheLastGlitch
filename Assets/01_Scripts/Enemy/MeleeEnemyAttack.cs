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
        // ���� ���� ���� ��� �ݶ��̴� ����
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, status.attackRadius, whatIsPlayer);

        // ������ �ݶ��̴� �� Player �±׸� ���� ������Ʈ ã��
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                // Player ������Ʈ�� �����ϴ� ����
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
