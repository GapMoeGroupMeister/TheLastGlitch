using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodsControl : MonoBehaviour
{
    public UnityEvent OnBuy;
    
    [SerializeField] protected Button buyBtn;
    public TestItemSO item {  get; set; }
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _toolTip;
    [SerializeField] protected TextMeshProUGUI _price;

   


    public void UpdateItem()
    {
        gameObject.SetActive(true);
        // ������ ����
        _icon.sprite = item._icon;
        _name.text = item._name;
        _toolTip.text = item._toolTip;
        _price.text = item._price + "";
        
        
    }

    public void BuyItem()
    {
        gameObject.SetActive(false);
        //�κ��丮 ����Ʈ�� ������ ������ �־���
        TestInventory.HaveItems.Add(item);

    }

    

}
