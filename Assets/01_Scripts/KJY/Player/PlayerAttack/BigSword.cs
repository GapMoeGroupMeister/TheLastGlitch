using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Experimental.GlobalIllumination;

public class BigSword : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _swordParent;

    private Sequence AttackSequence;

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
        if (!WeaponCoolTime.instance._attack)
        {
            AttackSequence = DOTween.Sequence();
            AttackSequence.Append(_swordParent.transform.DOLocalRotate(new Vector3(0, 0, -5), 0.25f, RotateMode.FastBeyond360));
            AttackSequence.AppendInterval(0.1f);
            AttackSequence.Append(_swordParent.transform.DOLocalRotate(new Vector3(0, 0, -180), 0.4f));
            AttackSequence.Play();
            StartCoroutine(AttackCoolTimeBG());
        }
    }

    private IEnumerator AttackCoolTimeBG()
    {
        WeaponCoolTime.instance._attack = true;
        yield return new WaitForSeconds(0.8f);
        WeaponCoolTime.instance._attack = false;
    }

}
