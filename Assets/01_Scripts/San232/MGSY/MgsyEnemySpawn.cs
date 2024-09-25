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

    private Coroutine enemySpawnRoutine;

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
        if (_minCoolTime > 0 && _maxCoolTime > _minCoolTime)
        {
            _spawnCoolTime = Random.Range(_minCoolTime, _maxCoolTime);
        }
        else
        {
            Debug.LogError("Cool Time ������ �߸��Ǿ����ϴ�.");
            _spawnCoolTime = 1f;  // �⺻�� ����
        }
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
        if (_enemys == null || _enemys.Count == 0)
        {
            Debug.LogError("Enemy ����Ʈ�� ��� �ֽ��ϴ�!");
            return;
        }

        if (_currentMobCount <= _mobCount)
        {
            int randIndex = Random.Range(0, _enemys.Count);  // +1 ����
            GameObject enemyGo = _enemys[randIndex].gameObject;

            if (enemyGo != null)
            {
                Instantiate(enemyGo, transform.position, Quaternion.identity);
                _currentMobCount++;
            }
            else
            {
                Debug.LogError($"_enemys[{randIndex}]�� gameObject�� null�Դϴ�.");
            }
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
        if (enemySpawnRoutine == null)
        {
            enemySpawnRoutine = StartCoroutine(MgsyEnemySpawnRoutine());
        }
    }

    public void EndEnemySpawn()
    {
        IsSpawning = false;
        if (enemySpawnRoutine != null)
        {
            StopCoroutine(enemySpawnRoutine);
            enemySpawnRoutine = null;
        }
    }
}
