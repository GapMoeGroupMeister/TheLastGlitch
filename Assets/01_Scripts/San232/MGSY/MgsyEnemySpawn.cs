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
    [SerializeField] private List<string> _enemyTypes = new List<string> { "Gun", "Soldier", "Tanker", "Boom" };
    [SerializeField] private PoolManager poolManager;

    protected override void Awake()
    {
        base.Awake();
        poolManager = PoolManager.Instance;

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
            // 적 선택
            int randEnemyIndex = Random.Range(0, _enemyTypes.Count);
            string enemyPoolName = _enemyTypes[randEnemyIndex];  // 적 타입에 맞게 이름 선택

            if (_spawnPoints.Count > 0)
            {
                int randPointIndex = Random.Range(0, _spawnPoints.Count);
                Transform spawnPoint = _spawnPoints[randPointIndex];

                // PoolManager에서 적 가져오기
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
