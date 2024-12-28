using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DisplayGoods : MonoBehaviour
{

    [SerializeField] protected GameObject _goods;
    [SerializeField] protected TestItemListSO items;
    [SerializeField] protected PassiveListSO passives;
    [SerializeField] protected TestItemSO item;
    [SerializeField] protected List<TestItemSO> displayedItems; //진열된 아이탬 리스트
    public EventBox eb;
    public MessageBox mb;
    public RectTransform canvas;



    public List<GoodsControl> Goods;

    private void Start()
    {
        displayedItems = new List<TestItemSO>();
        Goods = new List<GoodsControl>();
        for (int i = 0; i < Mathf.Clamp(items.list.Count - 1, 0, 4); i++)
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
            good.mb = mb;
            good.canvas = canvas;
            good.UpdateItem();
            Goods.Add(good);
            displayedItems.Add(good.item);

        }
        Debug.Log("상점 세팅됨");

    }



    // 상점 새로고침 
    public void UpdateGoods()
    {

        displayedItems.Clear();
        for (int i = 0; i < Mathf.Clamp(items.list.Count - 1, 0, 4); i++)
        {
            item = items.list[UnityEngine.Random.Range(0, items.list.Count - 1)];
            CheckDuplication(item);


            Goods[i].item = item;
            Goods[i].UpdateItem();
            displayedItems.Add(item);
            Debug.Log(displayedItems.Count);
            Debug.Log(displayedItems.Count);


        }
    }


    // 중복 탬 체크
    private bool CheckDuplication(TestItemSO item)
    {
        int a;
        try
        {
            a = GameManager.Instance.Player.GetComponentInChildren<PassiveManager>().HavePassiveList.Count;
        }
        catch (NullReferenceException)
        {
            a = 0;
        }

        if ((items.list.Count - (a + displayedItems.Count)) <= 1)
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
