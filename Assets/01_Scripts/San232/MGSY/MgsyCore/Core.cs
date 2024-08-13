using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [Header("Core Status")]
    [SerializeField] private Health _coreHealth;
    [SerializeField] private int _coreBombDamage;
    [SerializeField] private float _coreBombRadius;

    public static int coreCount;

    public DamageCaster CoreDamagerCaster { get; private set; }

    private void Awake()
    {
        CoreDamagerCaster = GetComponentInChildren<DamageCaster>();
    }

    public void Explode()
    {
        // ���� ���� ���� ��� �ݶ��̴� ��������
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _coreBombRadius);

        // �� �ݶ��̴��� ���� �ݺ��� ����
        foreach (Collider2D hitCollider in hitColliders)
        {
            // �� ��ü���� Ȯ��
            if (hitCollider.CompareTag("Enemy"))
            {
                // ������ ������ �ֱ�
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.HealthComponent.TakeDamage(_coreBombDamage, Vector3.zero, 0);
                }
            }
        }

        // ���� ȿ�� (�ִϸ��̼�, ��ƼŬ ��) �߰� ����
        Debug.Log("Explosion triggered!");
    }

    // ���� ���� �׸��� (����׿�)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _coreBombRadius);
    }
}
