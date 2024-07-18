using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyEnemySpawn : MonoBehaviour
{
    public bool IsSpawning { get; set; } = false;

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

    private void StartSpawnEnemy()
    {
        if(IsSpawning)
        {
            while (_mobCount == _currentMobCount)
            {
                //Spawn
                _currentMobCount++;
                _spawnCooltime = Random.Range(8, 21);
                StartCoroutine(SpawnCoolRoutine());
            }

            if (_mobCount == _currentMobCount)
            {
                _currentMobCount = 0;
                DecideCount();
            }
        }
    }

    private IEnumerator SpawnCoolRoutine()
    {
        yield return new WaitForSeconds(_spawnCooltime);
    }

}
