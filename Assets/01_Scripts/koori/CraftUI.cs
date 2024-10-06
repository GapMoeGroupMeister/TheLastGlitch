using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _battery, _pcb, _sensor, _metal, _gear;
    [SerializeField] private Button _exit;

    private void Start()
    {
        //_exit.onClick.Invoke( GameManager.Instance.Player.GetComponent<PlayerInteract>)
    }

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
