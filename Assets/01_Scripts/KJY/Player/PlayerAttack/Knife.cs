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

    private bool _isAttacking = false;

    private void Awake()
    {
        _input.OnAttackEvent += Attack;
    }

    private void OnEnable()
    {
        _input.OnAttackEvent += Attack;
    }

    private void OnDisable()
    {
        _input.OnAttackEvent -= Attack;
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
        yield return new WaitForSeconds(0.2f);
        WeaponCoolTime.instance._attack = false;
    }

    #region Trigger

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (WeaponCoolTime.instance._attack)
        {
            Debug.Log("KAttack");
            if (collision.gameObject.CompareTag("Enemy") && !_isAttacking)
            {
                _isAttacking = true;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isAttacking = false;
    }

#endregion
}
