using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private PlayerItemSO m_Item;

    [SerializeField] private TMP_Text _battery, _pcb, _sensor, _metal;

    private void OnEnable()
    {
        ReloadItemCount();
    }

    private void ReloadItemCount()
    {
        _battery.text = m_Item.requireItemDic[RequireItemType.battery].ToString();
        _pcb.text = m_Item.requireItemDic[RequireItemType.pcb].ToString();
        _sensor.text = m_Item.requireItemDic[RequireItemType.sensor].ToString();
        _metal.text = m_Item.requireItemDic[RequireItemType.metal].ToString();
    }
}
