using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class MgsyEnemySpawn : MGSYPattern
{
    public bool IsSpawning { get; set; } = false;

    [Header("Spawn Settings")]
    [SerializeField] private int _mobCount = 15;
    [SerializeField] private int _currentMobCount = 0;
    [SerializeField] private int _minCount = 7;
    [SerializeField] private int _maxCount = 14;
    [SerializeField] private List<Transform> _spawnPoints;

    [Header("Enemy Settings")]
    [SerializeField] private List<Enemy> _enemys;
    [SerializeField] private PoolManager poolManager;

    protected override void Awake()
    {
        base.Awake();
        poolManager = PoolManager.Instance;
        if (poolManager == null)
        {
            Debug.LogError("PoolManager not found!");
        }

        if (_spawnPoints == null || _spawnPoints.Count == 0)
        {
            Debug.LogError("Spawn points are not assigned!");
        }

        if (_enemys == null || _enemys.Count == 0)
        {
            Debug.LogError("Enemy list is empty or not assigned in Inspector.");
        }
        else
        {
            foreach (var enemy in _enemys)
            {
                Debug.Log($"Enemy: {enemy?.name}");
            }
        }

        Init(PatternTypeEnum.EnemySpawn);
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
            // Àû ¼±ÅÃ
            int randEnemyIndex = Random.Range(0, _enemys.Count);
            GameObject enemyGo = _enemys[randEnemyIndex].gameObject;

            if (_spawnPoints.Count > 0)
            {
                int randPointIndex = Random.Range(0, _spawnPoints.Count);
                Transform spawnPoint = _spawnPoints[randPointIndex];

                string enemyPoolName = enemyGo.name;

                if (enemyPoolName != "Dron")
                {
                    string FullName = enemyPoolName;
                    string enemyTag = "Enemy";
                    string enemyCode = FullName.Replace(enemyTag, "");
                    enemyPoolName = FullName;
                }

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
