using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public Pooling enemy;
    int Count = 0;
    private int SpawnNumber;
    float timerSpanwer = 0f;

    private void Start()
    {
         StartCoroutine(EnemySpawnCoolTime());
    }

    private IEnumerator EnemySpawnCoolTime()
    {
        while (Count < 10)
        {
            SpawnNumber = Random.Range(1, 5);
            switch (SpawnNumber)
            {
                case 1:
                    enemy = PoolManager.Instance.Pop("Gun") as Pooling;
                    enemy.gameObject.transform.position = transform.position;
                    Count++;
                    break;
                case 2:
                    enemy = PoolManager.Instance.Pop("Boom") as Pooling;
                    enemy.gameObject.transform.position = transform.position;
                    Count++;
                    break;
                case 3:
                    enemy = PoolManager.Instance.Pop("Dron") as Pooling;
                    enemy.gameObject.transform.position = transform.position;
                    Count++;
                    break;
                case 4:
                    enemy = PoolManager.Instance.Pop("Soldier") as Pooling;
                    enemy.gameObject.transform.position = transform.position;
                    Count++;
                    break;
                case 5:
                    enemy = PoolManager.Instance.Pop("Tanker") as Pooling;
                    enemy.gameObject.transform.position = transform.position;
                    Count++;
                    break;
                default:
                    Debug.LogError($"{SpawnNumber} ¹üÀ§ ¹þ¾î³²");
                    break;
            }
                    yield return new WaitForSeconds(0.5F);
        }

        Count = 0;
    }

    private void Update()
    {
        
        timerSpanwer += Time.deltaTime;
       

        Debug.Log(timerSpanwer);

        if (timerSpanwer > 15f)
        {
            StartCoroutine(EnemySpawnCoolTime());
            timerSpanwer = 0f;
        }
    }
}
