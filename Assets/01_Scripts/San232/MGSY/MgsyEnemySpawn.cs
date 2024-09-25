using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyEnemySpawn : MGSYPattern
{
    
    public bool IsSpawning { get; set; } = false;

    [Header("SpawnCount")]
    [SerializeField] private int _mobCount = 15;
    [SerializeField] private int _currentMobCount = 0;
    [SerializeField] private int _minCount = 7;
    [SerializeField] private int _maxCount = 14;

    

    [Header("EnemyList")]
    [SerializeField] private List<Enemy> _enemys = new List<Enemy>();

    private void Awake()
    {
        Init(PatternTypeEnum.EnemySpawn, this);
        ResetCount();
    }

    public override void PatternStart()
    {
        StartEnemySpawn();
    }

    public override void PatternEnd()
    {
        EndEnemySpawn();
    }

    private void SetCool()
    {
        _spawnCoolTime = 0;
        _spawnCoolTime = Random.Range(_minCoolTime, _maxCoolTime);
    }

    private void ResetCount()
    {
        _currentMobCount = 0;
        _mobCount = Random.Range(_minCount, _maxCount);
    }

    public void Spawn()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (_currentMobCount <= _mobCount)
        {
            int randIndex = Random.Range(0, _enemys.Count);
            GameObject enemyGo = _enemys[randIndex].gameObject;
            _currentMobCount++;
        }
        else if (_currentMobCount > _mobCount)
        {
            ResetCount();
        }
    }

    private IEnumerator MgsyEnemySpawnRoutine()
    {
        while (IsSpawning)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnCoolTime);
            SetCool();
        }
    }

    public void StartEnemySpawn()
    {
        IsSpawning = true;
        StartCoroutine(MgsyEnemySpawnRoutine());
    }

    public void EndEnemySpawn()
    {
        IsSpawning = false;
        StopCoroutine(MgsyEnemySpawnRoutine());
    }
}
