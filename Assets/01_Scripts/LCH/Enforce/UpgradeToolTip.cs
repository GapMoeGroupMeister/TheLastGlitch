using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UpgradeToolTip : MonoBehaviour
{
    [Header("Tooltip")]
    [SerializeField] private TextMeshProUGUI _tooltip;
    [Header("UseSmithy")]
    [SerializeField] private TextMeshProUGUI _useSmithy;
    [Header("Stage")]
    public int stage;

    private ReinforcemenSystem _upgradeCount;
    private WeaponManager _weaponManager;
    private void Awake()
    {
        _upgradeCount = GetComponent<ReinforcemenSystem>();
        _weaponManager = GameObject.Find("WeaponManager").GetComponent<WeaponManager>();
    }

    private void Start()
    {
        SetUpgradeTooltip();
    }

    public void SetUpgradeTooltip()
    {
        switch(_upgradeCount.UpgradeCount)
        {
            case 0:
                _tooltip.text = "���ݷ� ��ȭ : ���ݷ� " + Mathf.FloorToInt(_weaponManager._weaponQueue.Last()._damage/ 8) +" ����";
                break;
            case 1:
                _tooltip.text = "���ݷ� ��ȭ :  ���ݷ� " +  Mathf.FloorToInt(_weaponManager._weaponQueue.Last()._damage / 6) + " ����";
                break;
            case 2:
                _tooltip.text = "���ݷ� ��ȭ :  ���ݷ� " + Mathf.FloorToInt(_weaponManager._weaponQueue.Last()._damage * 2) + " ����";
                break;
            default:
                return;
        }
    }
}
