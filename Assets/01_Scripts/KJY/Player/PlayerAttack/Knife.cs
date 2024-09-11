using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Knife : PlayerWeaponParent
{
    public UnityEvent OnAttackEvent;

    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _knifeParent;
    [SerializeField] private GameObject _player;

    private CapsuleCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _input.OnAttackEvent += Attack;
    }

    private void Start()
    {
        _collider.enabled = false;
    }

    public void Attack()
    {
        if (_knifeParent.activeSelf == true)
        {
            if (!WeaponCoolTime.instance._attack)
            {
                
                transform.DOLocalMoveX(transform.localPosition.x + 0.5f, 0.1f).SetLoops(2, LoopType.Yoyo);
                StartCoroutine(AttackCoolTimeKA());
            }
        }
        
    }

    private IEnumerator AttackCoolTimeKA()
    {
        WeaponCoolTime.instance._attack = true;
        _collider.enabled = true;
        yield return new WaitForSeconds(0.2f);
        WeaponCoolTime.instance._attack = false;
        _collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (WeaponCoolTime.instance._attack)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (_player.transform.localScale.x > 0)
                {
                    float rand = Random.Range(0f, 101f);
                    if (rand <= criticalhHitProbability)
                    {
                        collision.gameObject.GetComponent<Health>().TakeDamage(damage * criticalHit, Vector2.right, knockBackPower);
                        return;
                    }

                    collision.gameObject.GetComponent<Health>().TakeDamage(damage, Vector2.right, knockBackPower);
                }

                if (_player.transform.localScale.x < 0)
                {
                    float rand = Random.Range(0f, 101f);
                    if (rand <= criticalhHitProbability)
                    {
                        collision.gameObject.GetComponent<Health>().TakeDamage(damage * criticalHit, Vector2.right, knockBackPower);
                        return;
                    }

                    collision.gameObject.GetComponent<Health>().TakeDamage(damage, Vector2.left, knockBackPower);
                }
                OnAttackEvent?.Invoke();
            }
        }
    }
}
