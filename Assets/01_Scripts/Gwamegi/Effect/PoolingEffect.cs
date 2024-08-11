using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingEffect : MonoBehaviour, Ipoolable
{
    [SerializeField] private string _poolName;

    public GameObject ObjectPrefab => gameObject;

    public string PoolName => _poolName;

    public void ResetItem()
    {
        transform.position = Vector3.zero;
    }

    private void OnDisable()
    {
        PoolManager.Instance.Push(this);
    }
}
