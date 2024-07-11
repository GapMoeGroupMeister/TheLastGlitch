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
        // �����Ƹ���Ʈ�� �ִ°� �߿� �ϳ� ����
        item = items.list[Random.Range(0, items.list.Count)];

        // ������ ����
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
            // �����Ƹ���Ʈ�� �ִ°� �߿� �ϳ� ����
            item = items.list[Random.Range(0, items.list.Count)];

            //���� ������ ��Ͼȵǰ� �ߺ� äũ
            while (TestInventory.HaveItems.Contains(item) || TestInventory.ItemCount == TestInventory.HaveItems.Count)
            {
                item = items.list[Random.Range(0, items.list.Count)];
            }

            // ������ ����
            _icon.sprite = item._icon;
            _name.text = item._name;
            _toolTip.text = item._toolTip;
            _price.text = item._price + "";
        }
    }

    public void BuyItem()
    {
        gameObject.SetActive(false);
        //�κ��丮 ����Ʈ�� ������ ������ �־���
        TestInventory.HaveItems.Add(item);
        TestInventory.ItemCount++;
    }

}
