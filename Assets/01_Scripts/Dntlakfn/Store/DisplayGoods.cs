using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class DisplayGoods : MonoBehaviour
{
    
    [SerializeField] protected GameObject _goods;
    [SerializeField] protected TestItemListSO items;
    [SerializeField] protected TestItemSO item;
    [SerializeField] protected List<TestItemSO> displayedItems; //������ ������ ����Ʈ
    public EventBox eb;
    


    public List<GoodsControl> Goods; 

    private void Awake()
    {
        displayedItems = new List<TestItemSO>();
        Goods = new List<GoodsControl>();
        for (int i = 0; i < Mathf.Clamp(items.list.Count-1, 0, 4); i++)
        {
            item = items.list[i];
            if (!CheckDuplication(item))
            {
                break;
            }
            
            GoodsControl good = Instantiate(_goods, transform).GetComponent<GoodsControl>();
            good.item = item;
            good._eb = eb;
            good.UpdateItem();
            Goods.Add(good);
            displayedItems.Add(good.item);

        }
        Debug.Log("���� ���õ�");

    }
    


    // ���� ���ΰ�ħ 
    public void UpdateGoods()
    {

        displayedItems.Clear();
        for (int i = 0; i < Mathf.Clamp(items.list.Count-1, 0, 4); i++)
        {
            item = items.list[Random.Range(0, items.list.Count-1)];
            CheckDuplication(item);
            
            
            Goods[i].item = item;
            Goods[i].UpdateItem();
            displayedItems.Add(item);
            Debug.Log(displayedItems.Count);
            Debug.Log(TestInventory.HaveItems.Count + displayedItems.Count);


        }
    }


    // �ߺ� �� üũ
    private bool CheckDuplication(TestItemSO item) // �ߺ� üũ
    {
        // �̰� ����
        if((items.list.Count - 1 - (TestInventory.HaveItems.Count + displayedItems.Count)) <= 0)
        {
            this.item = items.list.Last();
            return false;
        }
        while (true)
        {

            item = items.list[Random.Range(0, items.list.Count - 1)];
            if (!TestInventory.HaveItems.Contains(item) && !displayedItems.Contains(item))
            {
                break;
            }
            
        }
        this.item = item;
        return true;
        
    }
}
