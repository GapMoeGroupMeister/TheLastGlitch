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

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
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
