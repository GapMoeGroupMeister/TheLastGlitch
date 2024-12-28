using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingEffect : MonoBehaviour, Ipoolable
{
    [SerializeField] private string _poolName;

    private bool _isStart;

    public GameObject ObjectPrefab => gameObject;

    public string PoolName => _poolName;

    private void Start()
    {
        _isStart = true;
    }

    public void ResetItem()
    {
        transform.position = Vector3.zero;
    }

    private void OnDisable()
    {
        if (_isStart)
            PoolManager.Instance.Push(this);
    }
}
