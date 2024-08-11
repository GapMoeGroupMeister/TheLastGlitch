using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour, Ipoolable
{
    [SerializeField] private float _speed = 10f;

    [SerializeField] private float _maintainSec = 0.25f;

    [Header("Pool")]
    [SerializeField] private PoolItemSO _poolItem;
    [SerializeField] private GameObject _laserPrefab;

    public GameObject ObjectPrefab => _laserPrefab;

    public string PoolName => _poolItem.name;

    public void ResetItem()
    {
        
    }
}