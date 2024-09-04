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
        // 폭발 범위 내의 모든 콜라이더 가져오기
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _coreBombRadius);

        // 각 콜라이더에 대해 반복문 실행
        foreach (Collider2D hitCollider in hitColliders)
        {
            // 적 객체인지 확인
            if (hitCollider.CompareTag("Player"))
            {
                // 적에게 데미지 주기
                Player player = hitCollider.GetComponent<Player>();
                if (player != null)
                {
                    player.HealthComponent.TakeDamage(_coreBombDamage, Vector3.zero, 0);
                }
            }
        }

        // 파 티 클 넣 어
        Debug.Log("Explosion triggered!");
    }

    // 폭발 범위 그리기 (디버그용)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _coreBombRadius);
    }

}
