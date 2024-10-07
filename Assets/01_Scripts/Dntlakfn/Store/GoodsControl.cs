using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoodsControl : MonoBehaviour
{
    public Action OnBuy;
    
    [SerializeField] protected Button buyBtn;
    public TestItemSO item {  get; set; }
    [SerializeField] protected PassiveSO passive;
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _toolTip;
    [SerializeField] protected TextMeshProUGUI _price;
    public EventBox _eb;



    
    public void UpdateItem()
    {
        buyBtn.
        gameObject.SetActive(true);
        // ������ ����
        _icon.sprite = item._icon;
        _name.text = item._name;
        passive = item.passiveSO;
        _toolTip.text = (passive.addPlayerAtkPower != 0 ? $"���ݷ�  +{passive.addPlayerAtkPower}\n" : "")  + (passive.addPlayerCritDamage != 0f ? $"ġ��Ÿ ����  +{passive.addPlayerCritDamage}\n" : "") + (passive.addPlayerCritProbability != 0f ? $"ġ��Ÿ Ȯ��  +{passive.addPlayerCritProbability}%\n" : "") + (passive.addPlayerHealth != 0f ? $"ä��  +{passive.addPlayerHealth}\n" : "") + (passive.addPlayerMoveSpeed != 0f ? $"�̵��ӵ�  +{passive.addPlayerMoveSpeed}\n" : "") + $"\n{item._toolTip}";
        _price.text = item._price + "��";
        
        
        
    }

    public void BuyItem()
    {
        Money.money -= item._price;
        gameObject.SetActive(false);
        Debug.Log(item);
        //�κ��丮 ����Ʈ�� ������ ������ �־���
        PassiveManager.Instance.HavePassiveList.Add(item.passiveSO);
    }

    public void Click()
    {
        if(Money.money >= item._price)
        {
            OnBuy = BuyItem;
            _eb.SetEvent(OnBuy, "�����Ͻðڽ��ϱ�?");
        }
    }

   
}
