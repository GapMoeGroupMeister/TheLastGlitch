using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyEnemySpawn : MonoBehaviour
{
    [Header("SpawnCount")]
    [SerializeField] private int _mobCount = 15;
    [SerializeField] private int _currentMobCount = 0;

    [Header("CoolTime")]
    [SerializeField] private float _spawnCooltime = 0;

    private void Awake()
    {
        DecideCount();
    }

    private void DecideCount()
    {
        _mobCount = Random.Range(13, 26);
    }


}
