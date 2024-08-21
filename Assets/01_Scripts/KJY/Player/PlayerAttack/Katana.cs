using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private float _damage = 15f;
    [SerializeField] private GameObject _katanaParent;

    [SerializeField] private float _knockBackPower = 10f;
    [SerializeField] private float _swordSwingTime = 0.2f;
    [SerializeField] private float _swordReturnTime = 0.2f;

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
                AttackSequence.Append(_katanaParent.transform.DOLocalRotate(new Vector3(0, 0, _attackSequence1), _swordSwingTime, RotateMode.FastBeyond360));
                AttackSequence.Append(_katanaParent.transform.DOLocalRotate(new Vector3(0, 0, _attackSequence2), _swordReturnTime).SetEase(_ease));
                AttackSequence.Play();
                StartCoroutine(AttackCoolTimeKA());
            }
        }
    }

    private IEnumerator AttackCoolTimeKA()
    {
        WeaponCoolTime.instance._attack = true;
        yield return new WaitForSeconds(_swordSwingTime);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(_swordReturnTime);
        WeaponCoolTime.instance._attack = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (WeaponCoolTime.instance._attack)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Vector2 attackDir = new Vector2(Mathf.Clamp(Vector3.Cross(collision.gameObject.transform.position, transform.position).z, -1, 1), 0);
                collision.gameObject.GetComponent<Health>().TakeDamage(_damage, -attackDir, _knockBackPower);
            }
        }
    }
}
