using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

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
}
