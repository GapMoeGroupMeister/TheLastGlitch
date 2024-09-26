using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Health CoreHealthCompo
    {
        get
        {
            return _coreHealth;
        }
        set
        {
            _coreHealth = value;
        }
    }

    [Header("Explode Particle")]
    [SerializeField] private ParticleSystem _explodeParticle;

    [Header("Core Status")]
    [SerializeField] private Health _coreHealth;
    [SerializeField] private int _coreBombDamage;
    [SerializeField] private float _coreBombRadius;


    public static int coreCount = 2;

    public Action OnDestroyCore;

    public DamageCaster CoreDamagerCaster { get; private set; }

    [SerializeField] private MGSY _mgsy;

    private void Awake()
    {
        CoreDamagerCaster = GetComponentInChildren<DamageCaster>();
        _mgsy = transform.parent.gameObject.GetComponent<MGSY>();
        _explodeParticle = GetComponentInChildren<ParticleSystem>();
    }

    public void DestroyCore()
    {
        CoreExplode();
        --coreCount;
        gameObject.SetActive(false);
        OnDestroyCore?.Invoke();
    }

    private void CoreExplode()
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
        //CoreExplodeParticle();
        // �� Ƽ Ŭ �� ��
    }

    private void CoreExplodeParticle()
    {
        _explodeParticle.Play();
    }

    

    // ���� ���� �׸��� (����׿�)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _coreBombRadius);
    }

}
