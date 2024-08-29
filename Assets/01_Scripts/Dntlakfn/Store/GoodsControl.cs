using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodsControl : MonoBehaviour
{
    public Action OnBuy;
    
    [SerializeField] protected Button buyBtn;
    public TestItemSO item {  get; set; }
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _toolTip;
    [SerializeField] protected TextMeshProUGUI _price;
    public EventBox _eb;

   


    public void UpdateItem()
    {
        gameObject.SetActive(true);
        // 아이탬 셋팅
        _icon.sprite = item._icon;
        _name.text = item._name;
        _toolTip.text = item._toolTip;
        _price.text = item._price + "";
        
        
    }

    public void BuyItem()
    {
        Money.money -= int.Parse(_price.text);
        gameObject.SetActive(false);
        Debug.Log(item);
        //인벤토리 리스트에 구매한 아이탬 넣어줌
        TestInventory.HaveItems.Add(item);

    }

    public void Click()
    {
        if(Money.money >= int.Parse(_price.text))
        {
            OnBuy = BuyItem;
            _eb.SetEvent(OnBuy, "구매하시겠습니까?");
        }
        
    }

    

}
