using System;
using UnityEngine;

public class Core : MonoSingleton<Core>
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

    // coreCount�� MonoSingleton�� ���� ����
    public int CoreCount
    {
        get { return Instance._coreCount; }
        set { Instance._coreCount = value; }
    }

    [SerializeField] private int _coreCount = 2; // �ʱⰪ ����

    public Action OnDestroyCore;

    public DamageCaster CoreDamageCaster { get; private set; }

    [SerializeField] private MGSY _mgsy;

    private void Awake()
    {
        CoreDamageCaster = GetComponentInChildren<DamageCaster>();
        _mgsy = transform.parent.gameObject.GetComponent<MGSY>();
        _explodeParticle = GetComponentInChildren<ParticleSystem>();
        _coreHealth = GetComponent<Health>();
        _coreHealth.IsHittable = false;
    }

    public void DestroyCore()
    {
        CoreExplode();
        CoreCount--; // �̱����� ���� coreCount�� ���ҽ�Ŵ
        OnDestroyCore?.Invoke();
        gameObject.SetActive(false);
        
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
                CoreDamageCaster.CastDamge(_coreBombDamage, 0);
            }
        }
    }

    private void CoreExplodeParticle()
    {
        _explodeParticle.Play();
    }

    public void CoreHit()
    {
        CoreHealthCompo.AddCurrentHP(-20);
    }

    // ���� ���� �׸��� (����׿�)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _coreBombRadius);
    }
}
