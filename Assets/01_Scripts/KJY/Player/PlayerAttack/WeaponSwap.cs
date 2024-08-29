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

    [SerializeField] private GameObject _weapon1;
    [SerializeField] private GameObject _weapon2;

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
            StartCoroutine(SwapCool());
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
    private IEnumerator SwapCool()
    {
        yield return new WaitForSeconds(0.4f);
    }
}


