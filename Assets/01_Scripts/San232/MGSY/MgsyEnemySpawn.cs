using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyEnemySpawn : MonoBehaviour
{ 
    public bool IsSpawning { get; set; } = false;

    [Header("SpawnCount")]
    [SerializeField] private int _mobCount = 15;
    [SerializeField] private int _currentMobCount = 0;
    [SerializeField] private int _minCount = 7;
    [SerializeField] private int _maxCount = 14;

    [Header("CoolTime")]
    [SerializeField] private float _spawnCoolTime = 0;
    [SerializeField] private float _minCoolTime = 2;
    [SerializeField] private float _maxCoolTime = 4;
    [SerializeField] private float _patternCoolTime = 0;
    [SerializeField] private float _maxPatternCool = 6;
    [SerializeField] private float _minPatternCool = 12;

    [Header("EnemyList")]
    [SerializeField] private List<Enemy> _enemys = new List<Enemy>();

    private void Awake()
    {
        ResetCount();
    }

    private void ResetCount()
    {
        _currentMobCount = 0;
        _mobCount = Random.Range(_minCount, _maxCount);
    }

    private void StartSpawnEnemy()
    {
        //StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (IsSpawning)
        {
            if (_currentMobCount <= _mobCount)
            {
                int randIndex = Random.Range(0, _enemys.Count);
                GameObject enemyGo = _enemys[randIndex].gameObject;
                _currentMobCount++;
                float randCool = Random.Range(_minCoolTime, _maxCoolTime);
                yield return new WaitForSeconds(randCool);
            }
            else if (_currentMobCount > _mobCount)
            {
                ResetCount();
            }
            

        }
    }
}
