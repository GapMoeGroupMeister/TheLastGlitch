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

    [SerializeField] private MGSY _mgsy;

    private void Awake()
    {
        CoreDamagerCaster = GetComponentInChildren<DamageCaster>();
        _mgsy = transform.parent.gameObject.GetComponent<MGSY>();
    }

    public void DestroyCore()
    {
        coreCount--;
        gameObject.SetActive(false);
    }

    public void Explode()
    {
        // ���� ���� ���� ��� �ݶ��̴� ��������
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _coreBombRadius);

        // �� �ݶ��̴��� ���� �ݺ��� ����
        foreach (Collider2D hitCollider in hitColliders)
        {
            // �� ��ü���� Ȯ��
            if (hitCollider.CompareTag("Player"))
            {
                // ������ ������ �ֱ�
                Player player = hitCollider.GetComponent<Player>();
                if (player != null)
                {
                    player.HealthComponent.TakeDamage(_coreBombDamage, Vector3.zero, 0);
                }
            }
        }

        // �� Ƽ Ŭ �� ��
        Debug.Log("Explosion triggered!");
    }

    // ���� ���� �׸��� (����׿�)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _coreBombRadius);
    }

}
