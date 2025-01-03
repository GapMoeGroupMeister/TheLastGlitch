using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour, Ipoolable
{
    public string poolName;

    public string PoolName => poolName;

    public GameObject ObjectPrefab => gameObject;
    public Action OnReset;

    public void ResetItem()
    {
        OnReset?.Invoke();
    }
}
