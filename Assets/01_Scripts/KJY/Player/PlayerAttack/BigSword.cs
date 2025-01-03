using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class BigSword : PlayerWeaponParent
{
    public UnityEvent OnAttackEvent;
    public UnityEvent OnSoundEvent;

    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _swordParent;
    [SerializeField] private GameObject _player;
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private float _swordSwingTime = 0.25f;
    [SerializeField] private float _swordReturnTime = 0.4f;

    private DG.Tweening.Sequence AttackSequence;

    private void Start()
    {
        _input.OnAttackEvent += BigSwordAttack;
        
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        AttackSequence.Restart();
    }

    public void BigSwordAttack()
    {
        if (_swordParent.activeSelf == true)
        {
            if (!WeaponCoolTime.instance._attack)
            {
                OnSoundEvent.Invoke();
                AttackSequence = DOTween.Sequence();
                AttackSequence.AppendCallback(() => gameObject.GetComponent<CapsuleCollider2D>().enabled = true);
                AttackSequence.Append(_swordParent.transform.DOLocalRotate(new Vector3(0, 0, -130), _swordSwingTime, RotateMode.FastBeyond360).SetEase(Ease.InQuad));
                AttackSequence.AppendCallback(() => gameObject.GetComponent<CapsuleCollider2D>().enabled = false);
                AttackSequence.Append(_swordParent.transform.DOLocalRotate(new Vector3(0, 0, -180), _swordReturnTime));
                AttackSequence.Play();
                StartCoroutine(AttackCoolTimeBG());
            }
        }
    }

    private IEnumerator AttackCoolTimeBG()
    {
        WeaponCoolTime.instance._attack = true;
        yield return new WaitForSeconds(_swordSwingTime);
        yield return new WaitForSeconds(_swordReturnTime);
        WeaponCoolTime.instance._attack = false;
    }

    #region Trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (WeaponCoolTime.instance._attack)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (_player.transform.localScale.x > 0)
                {
                    float rand = Random.Range(0f,101f);
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
                        collision.gameObject.GetComponent<Health>().TakeDamage((damage * criticalHit), Vector2.left, knockBackPower);
                        return;
                    }

                    collision.gameObject.GetComponent<Health>().TakeDamage(damage, Vector2.left, knockBackPower);
                }
                OnAttackEvent?.Invoke();
            }
        }
    }

    #endregion
}
