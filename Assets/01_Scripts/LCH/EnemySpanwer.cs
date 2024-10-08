using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyPrefabs;
    private float randX;
    private float randY;
    int Count = 0;
    private int SpawnNumber;

    private void Start()
    {
         StartCoroutine(EnemySpawnCoolTime());
    }

    private IEnumerator EnemySpawnCoolTime()
    {
        while (true)
        {
            while (Count < 10)
            {
                randX = Random.Range(0.1f, 1.5f);
                randY = Random.Range(0.1f, 1f);
                float rand = Random.Range(1.0f, 10.1f);
                if (rand > 9.5f)
                    SpawnNumber = 0;
                else if(rand > 9f)
                    SpawnNumber = 1;
                else if(rand > 6)
                    SpawnNumber = 2;
                else if(rand > 3)
                    SpawnNumber = 3;
                else
                    SpawnNumber = 4;


                SpawnEnemy(SpawnNumber);
                yield return new WaitForSeconds(0.75F);
            }

            Count = 0;
            yield return new WaitForSeconds(12f);
        }
        
    }

    private void SpawnEnemy(int index)
    {
        Enemy enemy = Instantiate(_enemyPrefabs[index]);
        enemy.transform.position = transform.position + new Vector3(randX, randY);

        Count++;
    }
}