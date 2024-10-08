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

    // coreCount를 MonoSingleton을 통해 관리
    public int CoreCount
    {
        get { return Instance._coreCount; }
        set { Instance._coreCount = value; }
    }

    [SerializeField] private int _coreCount = 2; // 초기값 설정

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
        CoreCount--; // 싱글턴을 통해 coreCount를 감소시킴
        OnDestroyCore?.Invoke();
        gameObject.SetActive(false);
        
    }

    private void CoreExplode()
    {
        // 폭발 범위 내의 모든 콜라이더 가져오기
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _coreBombRadius);

        // 각 콜라이더에 대해 반복문 실행
        foreach (Collider2D hitCollider in hitColliders)
        {
            // 적 객체인지 확인
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

    // 폭발 범위 그리기 (디버그용)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _coreBombRadius);
    }
}
