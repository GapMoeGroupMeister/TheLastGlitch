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
        // 아이탬 셋팅
        _icon.sprite = item._icon;
        _name.text = item._name;
        passive = item.passiveSO;
        _toolTip.text = (passive.addPlayerAtkPower != 0 ? $"공격력  +{passive.addPlayerAtkPower}\n" : "")  + (passive.addPlayerCritDamage != 0f ? $"치명타 피해  +{passive.addPlayerCritDamage}\n" : "") + (passive.addPlayerCritProbability != 0f ? $"치명타 확률  +{passive.addPlayerCritProbability}%\n" : "") + (passive.addPlayerHealth != 0f ? $"채력  +{passive.addPlayerHealth}\n" : "") + (passive.addPlayerMoveSpeed != 0f ? $"이동속도  +{passive.addPlayerMoveSpeed}\n" : "") + $"\n{item._toolTip}";
        _price.text = item._price + "원";
        
        
        
    }

    public void BuyItem()
    {
        Money.money -= item._price;
        gameObject.SetActive(false);
        Debug.Log(item);
        //인벤토리 리스트에 구매한 아이탬 넣어줌
        PassiveManager.Instance.HavePassiveList.Add(item.passiveSO);
    }

    public void Click()
    {
        if(Money.money >= item._price)
        {
            OnBuy = BuyItem;
            _eb.SetEvent(OnBuy, "구매하시겠습니까?");
        }
    }

   
}
