using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GoodsSetting : MonoBehaviour
{
    [SerializeField] protected TestItemListSO items;
    [SerializeField] protected TestItemSO item;
    [SerializeField] protected Button buyBtn;

    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _toolTip;
    [SerializeField] protected TextMeshProUGUI _price;

    private void Awake()
    {
        buyBtn = GetComponent<Button>();
    }
    private void Start()
    {
        // 아이탬리스트에 있는것 중에 하나 뽑음
        item = items.list[Random.Range(0, items.list.Count)];

        // 아이탬 셋팅
        _icon.sprite = item._icon;
        _name.text = item._name;
        _toolTip.text = item._toolTip;
        _price.text = item._price + "";
    }

    public void UpdateItem()
    {
        gameObject.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            // 아이탬리스트에 있는것 중에 하나 뽑음
            item = items.list[Random.Range(0, items.list.Count)];

            //같은 아이탬 등록안되게 중복 채크
            while (TestInventory.HaveItems.Contains(item) || TestInventory.ItemCount == TestInventory.HaveItems.Count)
            {
                item = items.list[Random.Range(0, items.list.Count)];
            }

            // 아이탬 셋팅
            _icon.sprite = item._icon;
            _name.text = item._name;
            _toolTip.text = item._toolTip;
            _price.text = item._price + "";
        }
    }

    public void BuyItem()
    {
        gameObject.SetActive(false);
        //인벤토리 리스트에 구매한 아이탬 넣어줌
        TestInventory.HaveItems.Add(item);
        TestInventory.ItemCount++;
    }

}
