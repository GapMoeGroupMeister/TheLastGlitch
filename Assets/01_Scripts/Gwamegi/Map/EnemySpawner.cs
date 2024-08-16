using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnEnemyType
{
    Gun,
    Boom,
    Dron,
    Soldier,
    Tanker
}
public class EnemySpawner : MonoBehaviour
{
    public SpawnEnemyType type;

    public EnemyPooling enemy;

    private void Start()
    {
        EnemySpawn();
    }



    public void EnemySpawn()
    {
        switch (type)
        {
            case SpawnEnemyType.Gun:
                enemy = PoolManager.Instance.Pop("Gun") as EnemyPooling;
                enemy.gameObject.transform.position = transform.position;
                break;
            case SpawnEnemyType.Boom:
                enemy = PoolManager.Instance.Pop("Boom") as EnemyPooling;
                enemy.gameObject.transform.position = transform.position;
                break;
            case SpawnEnemyType.Dron:
                enemy = PoolManager.Instance.Pop("Dron") as EnemyPooling;
                enemy.gameObject.transform.position = transform.position;
                break;
            case SpawnEnemyType.Soldier:
                enemy = PoolManager.Instance.Pop("Soldier") as EnemyPooling;
                enemy.gameObject.transform.position = transform.position;
                break;
            case SpawnEnemyType.Tanker:
                enemy = PoolManager.Instance.Pop("Tanker") as EnemyPooling;
                enemy.gameObject.transform.position = transform.position;
                break;
            default: 
                break;
        }
    }
}
