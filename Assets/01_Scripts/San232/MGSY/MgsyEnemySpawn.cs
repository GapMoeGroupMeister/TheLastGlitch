using System.Collections;
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
        if (IsSpawning)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (_currentMobCount < _mobCount)
        {
            //Spawn
            _currentMobCount++;
            _spawnCooltime = Random.Range(8, 21);
            yield return new WaitForSeconds(_spawnCooltime);
        }

        _currentMobCount = 0;
        DecideCount();
    }
}
