using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _goToBossButton;
    [SerializeField] private PlayerItemData _playerItemData;

    private void Awake()
    {
        _goToBossButton.SetActive(false);
    }

    private void OnEnable()
    {
        CheckHaveAllGadgets();
    }

    private void CheckHaveAllGadgets()
    {
        foreach (var data in _playerItemData.havingGadgetDic)
        {
            if (data.Key != GadgetType.None)
            {
                if (data.Value == 0)
                    return;
            }
        }

        _goToBossButton.SetActive(true);
    }
}
