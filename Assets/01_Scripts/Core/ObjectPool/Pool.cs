using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool 
{
    private Stack<Ipoolable> _pool;
    private Transform _parentTrm;
    private Ipoolable _poolable;//Ǯ�� �ϰ� �ִ� Ŭ����
    private GameObject _prefab;//�̰� ���� ������

    public Pool(Ipoolable poolable, Transform parent, int count)
    {
        _pool = new Stack<Ipoolable>(count);
        _parentTrm = parent;
        _poolable = poolable;
        _prefab = poolable.ObjectPrefab;

        for(int i = 0; i<count; i++)
        {
            GameObject gamObj = GameObject.Instantiate(_prefab, _parentTrm);
            gamObj.SetActive(false);
            gamObj.name = _poolable.ItemName;
            Ipoolable item = gamObj.GetComponent<Ipoolable>();
            _pool.Push(item);
        }
    }

    public Ipoolable Pop()
    {
        Ipoolable item = null;

        if(_pool.Count==0)
        {
            GameObject gamObj = GameObject.Instantiate(_prefab, _parentTrm);
            gamObj.name = _poolable.ItemName;
            item = gamObj.GetComponent<Ipoolable>();
        }
        else
        {
            item = _pool.Pop();
            item.ObjectPrefab.SetActive(true);
        }

        return item;
    }

    public void Push(Ipoolable item)
    {
        item.ObjectPrefab.SetActive(false);
        _pool.Push(item);
    }
}
