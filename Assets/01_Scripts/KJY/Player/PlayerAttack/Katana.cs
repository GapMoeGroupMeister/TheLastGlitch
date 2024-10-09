using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Katana : PlayerWeaponParent
{
    public UnityEvent OnAttackEvent;

    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _katanaParent;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _swordSwingTime = 0.2f;
    [SerializeField] private float _swordReturnTime = 0.2f;

    [SerializeField] private int _attackSequence1;
    [SerializeField] private int _attackSequence2;
    [SerializeField] private Ease _ease;

    private Animator _anim;

    private Player2ActiveSkill _player2Active;

    private DG.Tweening.Sequence AttackSequence;

    private bool _isAttacking = false;
    private bool _useKatana = false;


    private void Awake()
    {
        _player2Active = GetComponentInParent<Player2ActiveSkill>();

        _anim = GetComponentInChildren<Animator>();

        _input.OnAttackEvent += KatanaAttack;
        _input.OnSwapingEvent += SwapAnim;
    }

    private void Start()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private void OnEnable()
    {
        AttackSequence.Restart();
    }


    private void SwapAnim()
    {
        if (_katanaParent.activeSelf == true)
        {
            if (!WeaponCoolTime.instance._attack)
            {
                if (!_useKatana)
                {
                    _anim.SetBool("KatanaReturn", true);
                    StartCoroutine(SwapCool());
                }
                else if (_useKatana)
                {
                    _anim.SetBool("KatanaReturn", false);
                }
            }
        }
    }

    public void KatanaAttack()
    {
        if (_katanaParent.activeSelf == true)
        {
            if (!WeaponCoolTime.instance._attack)
            {
                AttackSequence = DOTween.Sequence();
                AttackSequence.AppendCallback(() => gameObject.GetComponent<CapsuleCollider2D>().enabled = true);
                AttackSequence.Append(_katanaParent.transform.DOLocalRotate(new Vector3(0, 0, _attackSequence1), _swordSwingTime, RotateMode.FastBeyond360));
                AttackSequence.AppendCallback(() => gameObject.GetComponent<CapsuleCollider2D>().enabled = false);
                AttackSequence.Append(_katanaParent.transform.DOLocalRotate(new Vector3(0, 0, _attackSequence2), _swordReturnTime));
                AttackSequence.Play();
                StartCoroutine(AttackCoolTimeKA());
            }
        }
    }

    private IEnumerator AttackCoolTimeKA()
    {
        WeaponCoolTime.instance._attack = true;
        yield return new WaitForSeconds(_swordSwingTime);
        yield return new WaitForSeconds(_swordReturnTime);
        WeaponCoolTime.instance._attack = false;
    }

    private IEnumerator SwapCool()
    {
        _useKatana = true;
        yield return new WaitForSeconds(0.4f);
        _useKatana = false;
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
                        collision.gameObject.GetComponent<Health>().TakeDamage(damage * criticalHit, Vector2.left, knockBackPower);
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
