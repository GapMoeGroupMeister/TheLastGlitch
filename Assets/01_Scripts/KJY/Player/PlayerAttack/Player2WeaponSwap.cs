using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Player2WeaponSwap : MonoBehaviour
{
    public static Player2WeaponSwap Instance;

    [field: SerializeField] private InputReader _input;

    [Header("Player")]
    [SerializeField] private GameObject _player;

    [Header("Weapon")]
    [SerializeField] private GameObject _weapon1;
    [SerializeField] private GameObject _weapon2;

    public bool _isSwaping = false;

    private Sequence _swapSequence;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        _input.OnSwapingEvent += WeaponSwaping;
    }

    private void Start()
    {
        _weapon2.gameObject.SetActive(false);
    }

    private void WeaponSwaping()
    {
        if (!WeaponCoolTime.instance._attack)
        {
            if (!_isSwaping)
            {
                _isSwaping = true;
                StartCoroutine(SwapCool());

                if (_player.activeSelf == true)
                {
                    if (_weapon1.activeSelf == true)
                    {
                        _weapon1.SetActive(false);
                        _weapon2.SetActive(true);
                        _weapon2.transform.rotation = Quaternion.Euler(0, 0, 180);
                        _weapon2.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
                        _isSwaping = false;
                    }

                    else if (_weapon2.activeSelf == true)
                    {
                        _swapSequence = DOTween.Sequence();
                        _swapSequence.Append(_weapon2.transform.DOLocalRotate(new Vector3(0, 0, -140), 0.2f));
                        _swapSequence.AppendCallback(() =>
                        {
                            _weapon2.SetActive(false);
                        });
                        _swapSequence.AppendCallback(() =>
                        {
                            _weapon1.SetActive(true);
                        });
                        _isSwaping = false;
                    }
                }

            }
        }
    }

    private IEnumerator SwapCool()
    {
        WeaponCoolTime.instance._attack = true;
        yield return new WaitForSeconds(0.4f);
        WeaponCoolTime.instance._attack = false;
    }
}


