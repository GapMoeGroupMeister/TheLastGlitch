using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEditor.iOS;

public class BigSword : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _swordParent;

    private bool _attack = false;

    private void Awake()
    {
        _input.OnAttackEvent += Attack;
    }

    private void Update()
    {
        if (_input.MousePos.x > 0)
        {
            _swordParent.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        else if (_input.MousePos.x < 0)
        {
            _swordParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Attack()
    {
        if (!_attack)
        {
            if (_input.MousePos.x > 0)
            {
                Sequence AttackSequence = DOTween.Sequence();
                AttackSequence.Append(_swordParent.transform.DORotate(new Vector3(0, 0, 0), 0.3f));
                AttackSequence.Append(_swordParent.transform.DORotate(new Vector3(0, 0, 181), 0.3f));
                AttackSequence.Play();
                StartCoroutine(AttackCoolTime());
            }

            else if (_input.MousePos.x < 0)
            {
                Sequence AttackSequence = DOTween.Sequence();
                AttackSequence.Append(_swordParent.transform.DORotate(new Vector3(0, 0, 180), 0.3f));
                AttackSequence.Append(_swordParent.transform.DORotate(new Vector3(0, 0, -1), 0.3f));
                AttackSequence.Play();
                StartCoroutine(AttackCoolTime());
            }
        }
    }

    private IEnumerator AttackCoolTime()
    {
        _attack = true;
        yield return new WaitForSeconds(0.8f);
        _attack = false;
    }
}
