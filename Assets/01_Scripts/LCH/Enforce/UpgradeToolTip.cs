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
    public int Stage;

    public float Damage;

    private ReinforcemenSystem _upgradeCount;
    protected Upgrade _weaponDamage;
    private void Awake()
    {
        _upgradeCount = GetComponent<ReinforcemenSystem>();
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
                _tooltip.text = "���ݷ� ��ȭ:" + Damage/8 +"����";
                break;
            case 1:
                _tooltip.text = "���ݷ� ��ȭ:" + Damage / 6 + "����";
                break;
            case 2:
                _tooltip.text = "���ݷ� ��ȭ:" + Damage * 2 + "����";
                break;
            default:
                return;
        }
    }
}
