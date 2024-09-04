using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _battery, _pcb, _sensor, _metal, _gear;

    private void OnEnable()
    {
        ReloadItemCount();
    }

    public void ReloadItemCount()
    {
        _battery.text = PlayerItemSO.Instance.requireItemDic[RequireItemType.battery].ToString();
        _pcb.text = PlayerItemSO.Instance.requireItemDic[RequireItemType.pcb].ToString();
        _sensor.text = PlayerItemSO.Instance.requireItemDic[RequireItemType.sensor].ToString();
        _metal.text = PlayerItemSO.Instance.requireItemDic[RequireItemType.metal].ToString();
        _gear.text = PlayerItemSO.Instance.requireItemDic[RequireItemType.gear].ToString();
    }
}
