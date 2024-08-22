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
    public EventBox eb;
    
    public List<GoodsControl> Goods; //������ ������ ����Ʈ

    private void Awake()
    {
        
        Goods = new List<GoodsControl>();
        for (int i = 0; i < Mathf.Clamp(items.list.Count-1, 0, 6); i++)
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

        }
        Debug.Log("���� ���õ�");

    }
    


    // ���� ���ΰ�ħ 
    public void UpdateGoods()
    {
        

        for (int i = 0; i < Mathf.Clamp(items.list.Count-1, 0, 6); i++)
        {
            item = items.list[Random.Range(0, items.list.Count-1)];
            CheckDuplication(item);
            Goods[i].item = item;
            
            Goods[i].UpdateItem();
            

        }
    }


    // �ߺ� �� üũ
    private bool CheckDuplication(TestItemSO item) // �ߺ� üũ
    {
        if(TestInventory.HaveItems.Count >= items.list.Count)
        {
            this.item = items.list.Last();
            return false;
        }
        while (TestInventory.HaveItems.Contains(item))
        {
            item = items.list[Random.Range(0, items.list.Count)];
        }
        this.item = item;
        return true;
        
    }
}
