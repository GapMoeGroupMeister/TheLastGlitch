using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private float _damage = 15f;
    [SerializeField] private GameObject _katanaParent;

    [SerializeField] private int _attackSequence1;
    [SerializeField] private int _attackSequence2;
    [SerializeField] private Ease _ease;

    private DG.Tweening.Sequence AttackSequence;

    private void Awake()
    {
        _input.OnAttackEvent += KatanaAttack;
    }

    public void KatanaAttack()
    {
        if (_katanaParent.activeSelf == true)
        {
            if (!WeaponCoolTime.instance._attack)
            {
                AttackSequence = DOTween.Sequence();
                AttackSequence.Append(_katanaParent.transform.DOLocalRotate(new Vector3(0, 0, _attackSequence1), 0.1f, RotateMode.FastBeyond360));
                AttackSequence.Append(_katanaParent.transform.DOLocalRotate(new Vector3(0, 0, _attackSequence2), 0.3f).SetEase(_ease));
                AttackSequence.Play();
                StartCoroutine(AttackCoolTimeKA());
            }
        }
    }

    private IEnumerator AttackCoolTimeKA()
    {
        WeaponCoolTime.instance._attack = true;
        yield return new WaitForSeconds(0.4f);
        WeaponCoolTime.instance._attack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (WeaponCoolTime.instance._attack)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(_damage, Vector2.right, 2);
            }
        }
    }
}
