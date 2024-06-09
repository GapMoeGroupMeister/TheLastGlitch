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

    public float damage;

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
                _tooltip.text = "공격력 강화:" + damage/8 +"증가";
                break;
            case 1:
                _tooltip.text = "공격력 강화:" + damage / 6 + "증가";
                break;
            case 2:
                _tooltip.text = "공격력 강화:" + damage * 2 + "증가";
                break;
            default:
                return;
        }
    }
}
