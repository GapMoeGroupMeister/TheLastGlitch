using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GadgetEquip : MonoBehaviour
{
    [SerializeField] private Button _doping, _hack, _aed, _shield, _rocket;
    [SerializeField] private TMP_Text _dopingCount, _hackCount, _aedCount, _shieldCount, _rocketCount;

    private Dictionary<GadgetType, TMP_Text> _countTextDic;

    private Button GetGadgetButton(GadgetType type)
    {
        switch (type)
        {
            case GadgetType.doping: return _doping;
            case GadgetType.hackPulse: return _hack;
            case GadgetType.aed: return _aed;
            case GadgetType.shield: return _shield;
            case GadgetType.rocketLauncher: return _rocket;
            default: return null;
        }
    }

    private void Start()
    {
        _countTextDic = new Dictionary<GadgetType, TMP_Text>()
        {
            { GadgetType.doping, _dopingCount },
            { GadgetType.hackPulse, _hackCount },
            { GadgetType.aed, _aedCount },
            { GadgetType.shield, _shieldCount },
            { GadgetType.rocketLauncher, _rocketCount },
        };

        InitializeButtons();
    }

    public void InitializeButtons()
    {
        foreach (GadgetType gadgetType in Enum.GetValues(typeof(GadgetType)))
        {
            if (gadgetType == GadgetType.None) continue;

            Button button = GetGadgetButton(gadgetType);
            TMP_Text countText = _countTextDic[gadgetType];

            if (button != null)
            {
                int count = PlayerItemData.Instance.havingGadgetDic[gadgetType];
                countText.text = $"{count} º¸À¯";

                if (count == 0)
                {
                    button.interactable = false;
                    button.GetComponentInChildren<TMP_Text>().text = "¾øÀ½";
                }
                else
                {
                    button.interactable = true;
                    button.GetComponentInChildren<TMP_Text>().text = "ÀåÂø";
                }
            }

            if (PlayerItemData.Instance.CurrentGadget != GadgetType.None)
            {
                Button currentButton = GetGadgetButton(PlayerItemData.Instance.CurrentGadget); 
                if (currentButton != null)
                {
                    currentButton.interactable = false;
                    currentButton.GetComponentInChildren<TMP_Text>().text = "ÀåÂøÁß";
                }
            }
        }

        Button currentGadgetButton = GetGadgetButton(PlayerItemData.Instance.CurrentGadget);
        if (currentGadgetButton != null)
        {
            currentGadgetButton.interactable = false;
            currentGadgetButton.GetComponentInChildren<TMP_Text>().text = "ÀåÂøÁß";
        }
    }

    public void GadgetEquipBtn(string type)
    {
        GadgetType selectedGadgetType = (GadgetType)Enum.Parse(typeof(GadgetType), type);

        if (selectedGadgetType == GadgetType.None) return;

        PlayerItemData.Instance.CurrentGadget = selectedGadgetType;

        foreach (GadgetType gadgetType in Enum.GetValues(typeof(GadgetType)))
        {
            Button button = GetGadgetButton(gadgetType);
            if (button != null)
            {
                int count = PlayerItemData.Instance.havingGadgetDic[gadgetType];

                if (count == 0)
                {
                    button.interactable = false;
                    button.GetComponentInChildren<TMP_Text>().text = "¾øÀ½";
                }
                else
                {
                    button.interactable = true;
                    button.GetComponentInChildren<TMP_Text>().text = "ÀåÂø";
                }
            }
        }

        Button selectedButton = GetGadgetButton(selectedGadgetType);
        if (selectedButton != null)
        {
            selectedButton.interactable = false;
            selectedButton.GetComponentInChildren<TMP_Text>().text = "ÀåÂøÁß";
        }
    }
}