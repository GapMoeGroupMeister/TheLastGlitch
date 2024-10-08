using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _battery, _pcb, _sensor, _metal, _gear;

    private void Start()
    {
        ReloadItemCount();
    }

    public void ReloadItemCount()
    {
        _battery.text = PlayerItemData.Instance.requireItemDic[RequireItemType.battery].ToString();
        _pcb.text = PlayerItemData.Instance.requireItemDic[RequireItemType.pcb].ToString();
        _sensor.text = PlayerItemData.Instance.requireItemDic[RequireItemType.sensor].ToString();
        _metal.text = PlayerItemData.Instance.requireItemDic[RequireItemType.metal].ToString();
        _gear.text = PlayerItemData.Instance.requireItemDic[RequireItemType.gear].ToString();
    }
}
