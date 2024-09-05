using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class WeaponSwap : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [Header("Player")]
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;

    [Header("Weapon")]
    [SerializeField] private GameObject _weapon1;
    [SerializeField] private GameObject _weapon2;

    private bool _isSwaping = false;

    private Sequence _swapSequence;

    private void Awake()
    {
        _input.OnSwapingEvent += WeaponSwaping;
    }

    private void Start()
    {
    }

    private void WeaponSwaping()
    {
        if (!WeaponCoolTime.instance._attack)
        {
            if (!_isSwaping)
            {
                StartCoroutine(SwapCool());

                if (_player2.activeSelf)
                {
                    if (_weapon1.activeSelf)
                    {
                        _weapon1.SetActive(false);
                        _weapon2.SetActive(true);
                        _weapon2.transform.rotation = Quaternion.Euler(0, 0, 0);
                        _weapon2.transform.DOLocalRotate(new Vector3(0, 0, 260), 0.3f);
                    }

                    else if (_weapon2.activeSelf)
                    {
                        _swapSequence = DOTween.Sequence();
                        _swapSequence.Append(_weapon2.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.3f));
                        _swapSequence.AppendCallback(() =>
                        {
                            _weapon2.SetActive(false);
                        });
                        _swapSequence.AppendCallback(() =>
                        {
                            _weapon1.SetActive(true);
                        });
                    }
                }

                if (_player1.activeSelf)
                {
                    if (_weapon1.activeSelf)
                    {
                        _weapon1.SetActive(false);
                        _weapon2.SetActive(true);
                    }

                    else if (_weapon2.activeSelf)
                    {
                        _weapon2.SetActive(false);
                        _weapon1.SetActive(true);
                    }
                }
            }
        }
    }

    private IEnumerator SwapCool()
    {
        _isSwaping = true;
        WeaponCoolTime.instance._attack = true;
        yield return new WaitForSeconds(0.4f);
        _isSwaping = false;
        WeaponCoolTime.instance._attack = false;
    }
}


