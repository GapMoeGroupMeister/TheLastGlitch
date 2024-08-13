using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _weapon1;
    [SerializeField] private GameObject _weapon2;

    private bool _weapon1SW;
    private bool _weapon2SW;

    private bool _swapCoolTime;

    private void Awake()
    {
        _input.OnSwapingEvent += WeaponSwaping;
    }

    private void WeaponSwaping()
    {
        if (!WeaponCoolTime.instance._attack)
        {
            StartCoroutine(SwapCool());
            if (!_weapon1SW)
            {
                _weapon1.SetActive(false);
                _weapon2.SetActive(true);
                _weapon1SW = true;
                _weapon2SW = false;
            }

            else if (!_weapon2SW)
            {
                _weapon2.SetActive(false);
                _weapon1.SetActive(true);
                _weapon2SW = true;
                _weapon1SW = false;
            }
        }
    }
    private IEnumerator SwapCool()
    {
        yield return new WaitForSeconds(0.4f);
    }
}


