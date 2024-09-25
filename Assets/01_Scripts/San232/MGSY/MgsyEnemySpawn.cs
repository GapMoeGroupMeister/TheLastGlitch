using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyEnemySpawn : MGSYPattern
{
    public bool IsSpawning { get; set; } = false;

    [Header("Spawn Settings")]
    [SerializeField] private int _mobCount = 15;
    [SerializeField] private int _currentMobCount = 0;
    [SerializeField] private int _minCount = 7;
    [SerializeField] private int _maxCount = 14;
    [SerializeField] private List<Transform> spawnPoints;

    [Header("Enemy Settings")]
    [SerializeField] private List<Enemy> _enemys = new List<Enemy>();
    [SerializeField] private PoolManager poolManager;

    private void Awake()
    {
        poolManager = PoolManager.Instance;
        if (poolManager == null)
        {
            Debug.LogError("PoolManager not found!");
        }

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("Spawn points are not assigned!");
        }

        if (_enemys == null || _enemys.Count == 0)
        {
            Debug.LogError("Enemy list is empty!");
        }

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
        _spawnCoolTime = Random.Range(_minCoolTime, _maxCoolTime);
    }

    private void ResetCount()
    {
        _currentMobCount = 0;
        _mobCount = Random.Range(_minCount, _maxCount);
    }

    private void Spawn()
    {
        if (_currentMobCount < _mobCount)
        {
            // �� ����
            int randEnemyIndex = Random.Range(0, _enemys.Count);
            GameObject enemyGo = _enemys[randEnemyIndex].gameObject;

            if (spawnPoints.Count > 0)
            {
                int randPointIndex = Random.Range(0, spawnPoints.Count);
                Transform spawnPoint = spawnPoints[randPointIndex];

                string enemyPoolName = enemyGo.name;
                Ipoolable enemy = poolManager.Pop(enemyPoolName);
                if (enemy != null)
                {
                    enemy.ObjectPrefab.transform.position = spawnPoint.position;
                    enemy.ObjectPrefab.transform.rotation = spawnPoint.rotation;
                }
                else
                {
                    Debug.LogError($"Failed to spawn enemy from pool: {enemyPoolName}");
                }
            }

            _currentMobCount++;
        }
        else if (_currentMobCount >= _mobCount)
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
