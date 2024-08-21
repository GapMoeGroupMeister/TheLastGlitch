using System.Collections;
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

    private void Awake()
    {
        DecideCount();
    }

    private void ResetCount()
    {
        _currentMobCount = 0;
    }

    private void DecideCount()
    {
        _mobCount = Random.Range(_minCount, _maxCount);
    }

    private void StartSpawnEnemy()
    {
        if (IsSpawning)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (_currentMobCount < _mobCount)
        {

            if(_currentMobCount >= _mobCount)
            {
                _patternCoolTime = Random.Range(_minPatternCool, _maxPatternCool);
                yield return new WaitForSeconds(_patternCoolTime);
                DecideCount();
            }
            else
            {
                _currentMobCount++;
                _spawnCoolTime = Random.Range(_minCoolTime, _maxCoolTime);
                yield return new WaitForSeconds(_spawnCoolTime);

            }
        }

        
    }
}
