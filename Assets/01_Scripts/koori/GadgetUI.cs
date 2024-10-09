using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class GadgetUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] Sprite _doping, _hack, _aed, _shield, _rocket, _non;
    [SerializeField] InputReader _reader;

    private void Awake()
    {
        _reader.OnUseGadgetEvent += UseGadget;
        
    }
    private void Start()
    {
        Reset();
        if (PlayerItemData.Instance.CurrentGadget == GadgetType.aed)
        {
            PlayerItemData.Instance.GadgetInit(GadgetType.aed);
            PlayerItemData.Instance.GadgetMinus(GadgetType.aed);
            PlayerItemData.Instance.CurrentGadget = GadgetType.None;
        }
    }

    private void UseGadget()
    {
        Debug.Log("가젯 키 눌림");
        if(PlayerItemData.Instance.CurrentGadget != GadgetType.None&&PlayerItemData.Instance.CurrentGadget != GadgetType.aed)
        {
            Debug.Log("가젯 소환 시작");
            PlayerItemData.Instance.GadgetInit(PlayerItemData.Instance.CurrentGadget);
            PlayerItemData.Instance.GadgetMinus(PlayerItemData.Instance.CurrentGadget);
            PlayerItemData.Instance.CurrentGadget = GadgetType.None;

            Reset();
        }
    }

    private void Reset()
    {
        Debug.Log(PlayerItemData.Instance.CurrentGadget);
        _image.sprite = GetCurrentType(PlayerItemData.Instance.CurrentGadget);
    }

    private Sprite GetCurrentType(GadgetType currentGadget)
    {
        switch (currentGadget)
        {
            case GadgetType.doping: return _doping;
            case GadgetType.aed: return _aed;
            case GadgetType .shield: return _shield;
            case GadgetType.rocketLauncher: return _rocket;
            case GadgetType.hackPulse: return _hack;

            default : return _non;
        }
    }
}
