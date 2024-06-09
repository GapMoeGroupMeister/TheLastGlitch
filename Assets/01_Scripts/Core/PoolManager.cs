using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private PoolListSO _poolList;

    private Dictionary<string, Pool> _pools;

    private void Awake()
    {
        _pools = new Dictionary<string, Pool>();
        foreach(PoolItemSO pair in _poolList.list)
        {
            createPooll(pair , pair.count);
        }
    }

    private void createPooll(PoolItemSO pair, int count)
    {
        Ipoolable poolable = pair.prefab.GetComponent<Ipoolable>();
        if(poolable == null)
        {
            Debug.LogWarning($"GameObject {pair.prefab.name} has no Ipoolable Script");
            return;
        }

        Pool pool = new Pool(poolable, transform, count);
        _pools.Add(poolable.ItemName, pool); //µñ¼Å³Ê¸®¿¡ Ãß°¡
    }

    public Ipoolable Pop(string itemName)
    {
        if(_pools.ContainsKey(itemName))
        {
            Ipoolable item = _pools[itemName].Pop();
            item.ResetItem();
            return item;
        }
        Debug.LogError($"Ther is no pool {itemName}");
        return null;
    }

    public void Push(Ipoolable item)
    {
        if(_pools.ContainsKey(item.ItemName))
        {
            _pools[item.ItemName].Push(item);
            return;
        }

        Debug.LogError($"There is no pool {item.ItemName}");
    }
}
