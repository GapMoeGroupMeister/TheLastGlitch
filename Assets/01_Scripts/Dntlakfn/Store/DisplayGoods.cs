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
    
    public List<GoodsControl> Goods;

    private void Awake()
    {
        Goods = new List<GoodsControl>();
        item = items.list[Random.Range(0, items.list.Count)];
        Debug.Log(item);
        //CheckDuplication(item);
        for (int i = 0; i < Mathf.Clamp(items.list.Count, 0, 6); i++)
        {
            GoodsControl good = Instantiate(_goods, transform).GetComponent<GoodsControl>();
            good.item = item;
            good.UpdateItem();
            Goods.Add(good);

        }

        
    }
    


    public void UpdateGoods()
    {
        item = items.list[Random.Range(0, items.list.Count)];
        //CheckDuplication(item);
        for (int i = 0; i < Mathf.Clamp(items.list.Count, 0, 6); i++)
        {
            Goods[i].item = item;
            Goods[i].UpdateItem();
            

        }
    }


    private void CheckDuplication(TestItemSO item) // 중복 채크
    {
        while (TestInventory.HaveItems.Contains(item) && !(TestInventory.HaveItems.Count >= items.list.Count))
        {
            item = items.list[Random.Range(0, items.list.Count)];
        }
        this.item = item;
        
    }
}
