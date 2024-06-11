using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    public float attackRadius;
    public float chaseSpeed;
    public float attackPower;
    public float attackSpeed;
    public float health;
}
