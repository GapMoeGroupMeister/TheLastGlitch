using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private float _damage = 15f;

    private void Awake()
    {
        _input.OnAttackEvent += KatanaAttack;
    }

    public void KatanaAttack()
    {
        if (!WeaponCoolTime.instance._attack)
        {
            transform.DOLocalMoveX(transform.localPosition.x - 0.7f, 0.1f).SetLoops(2, LoopType.Yoyo);
            StartCoroutine(AttackCoolTimeKA());

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
