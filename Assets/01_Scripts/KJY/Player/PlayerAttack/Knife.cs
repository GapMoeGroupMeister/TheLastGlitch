using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knife : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _knifeParent;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _knockBackPower = 20f;

    private bool _attack = false;

    private void Awake()
    {
        _input.OnAttackEvent += Attack;
    }

    public void Attack()
    {
        if (_knifeParent.activeSelf == true)
        {
            if (!WeaponCoolTime.instance._attack)
            {
                transform.DOLocalMoveX(transform.localPosition.x + 0.7f, 0.1f).SetLoops(2, LoopType.Yoyo);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (WeaponCoolTime.instance._attack)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (_player.transform.localScale.x > 0)
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(_damage, Vector2.right, _knockBackPower);
                }

                if (_player.transform.localScale.x < 0)
                {
                    collision.gameObject.GetComponent<Health>().TakeDamage(_damage, Vector2.left, _knockBackPower);
                }
            }
        }
    }
}
