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
    
    public List<GoodsControl> Goods; //진열된 아이탬 리스트

    private void Awake()
    {
        Goods = new List<GoodsControl>();
        
        Debug.Log(item);

        //CheckDuplication(item); 이거 고쳐라

        for (int i = 0; i < Mathf.Clamp(items.list.Count, 0, 6); i++)
        {
            item = items.list[i];
            GoodsControl good = Instantiate(_goods, transform).GetComponent<GoodsControl>();
            good.item = item;
            good.UpdateItem();
            Goods.Add(good);

        }

        
    }
    


    // 상점 새로고침 
    public void UpdateGoods()
    {
        item = items.list[Random.Range(0, items.list.Count)];

        //CheckDuplication(item); 이거 고쳐라

        for (int i = 0; i < Mathf.Clamp(items.list.Count, 0, 6); i++)
        {
            Goods[i].item = item;
            Goods[i].UpdateItem();
            

        }
    }


    // 중복 탬 체크
    private void CheckDuplication(TestItemSO item) // 중복 체크
    {
        while (TestInventory.HaveItems.Contains(item) && !(TestInventory.HaveItems.Count >= items.list.Count))
        {
            item = items.list[Random.Range(0, items.list.Count)];
        }
        this.item = item;
        
    }
}
