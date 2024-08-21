using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.VisualScripting;

public class BigSword : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _swordParent;
    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private float _damage = 30f;
    [SerializeField] private float _knockBackPower = 10f;

    [SerializeField] private float _swordSwingTime = 0.25f;
    [SerializeField] private float _swordReturnTime = 0.4f;

    private DG.Tweening.Sequence AttackSequence;

    private void Awake()
    {
        _input.OnAttackEvent += BigSwordAttack;
    }

    private void Start()
    {
        AttackSequence.Restart();
    }

    private void Update()
    {

    }


    public void BigSwordAttack()
    {
        if (_swordParent.activeSelf == true)
        {
            if (!WeaponCoolTime.instance._attack)
            {
                AttackSequence = DOTween.Sequence();
                AttackSequence.Append(_swordParent.transform.DOLocalRotate(new Vector3(0, 0, -130), _swordSwingTime, RotateMode.FastBeyond360));
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
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(_swordReturnTime);
        WeaponCoolTime.instance._attack = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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
