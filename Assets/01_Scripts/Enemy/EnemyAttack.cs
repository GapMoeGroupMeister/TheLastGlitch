using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected LayerMask whatIsPlayer;
    [SerializeField] protected Health _playerHealth;
    [SerializeField] protected GameObject _player;
    public EnemyDataSO status;
}
