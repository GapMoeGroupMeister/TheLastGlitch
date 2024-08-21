using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knife : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _knifeParent;

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
                Vector2 attackDir = new Vector2(Mathf.Clamp(Vector3.Cross(collision.gameObject.transform.position, transform.position).z, -1, 1), 0);
                collision.gameObject.GetComponent<Health>().TakeDamage(_damage, -attackDir, _knockBackPower);
            }
        }
    }
}
