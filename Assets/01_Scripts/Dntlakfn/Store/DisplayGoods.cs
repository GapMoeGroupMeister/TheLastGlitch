using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class DisplayGoods : MonoBehaviour
{
    
    [SerializeField] protected GameObject _goods;
    [SerializeField] protected TestItemListSO items;
    [SerializeField] protected PassiveListSO passives;
    [SerializeField] protected TestItemSO item;
    [SerializeField] protected List<TestItemSO> displayedItems; //������ ������ ����Ʈ
    public EventBox eb;
    


    public List<GoodsControl> Goods; 

    private void Awake()
    {
        displayedItems = new List<TestItemSO>();
        Goods = new List<GoodsControl>();
        eb = FindAnyObjectByType<EventBox>();
        for (int i = 0; i < Mathf.Clamp(items.list.Count-1, 0, 4); i++)
        {
            
            item = items.list[i];
            item.passiveSO = passives.passiveSOList[i];
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
            item = items.list[UnityEngine.Random.Range(0, items.list.Count-1)];
            CheckDuplication(item);
            
            
            Goods[i].item = item;
            Goods[i].UpdateItem();
            displayedItems.Add(item);
            Debug.Log(displayedItems.Count);
            Debug.Log(displayedItems.Count);


        }
    }


    // �ߺ� �� üũ
    private bool CheckDuplication(TestItemSO item)
    {
        int a;
        try
        {
            a = PassiveManager.Instance.HavePassiveList.Count;
        }
        catch(NullReferenceException)
        {
            a = 0;
        }
        
        if ((items.list.Count - (a + displayedItems.Count)) <= 0)
        {
            this.item = items.list.Last();
            return false;
        }
        while (true)
        {
            int rand = UnityEngine.Random.Range(0, items.list.Count - 1);
            item = items.list[rand];
            item.passiveSO = passives.passiveSOList[rand];
            if (!displayedItems.Contains(item))
            {
                break;
            }
            
        }
        this.item = item;
        return true;
        
    }
}
