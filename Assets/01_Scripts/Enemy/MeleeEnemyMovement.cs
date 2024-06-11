using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyMovement : MonoBehaviour
{
    public EnemyDataSO stats;
    [SerializeField] private Transform _target;
    private Rigidbody2D _rigid;
    private Vector3 targetPosition;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_target != null)
        {
            PlayerDirection();
        }
    }

    private void FixedUpdate()
    {
        GotoPlayer();
    }

    void PlayerDirection()
    {
        targetPosition = new Vector3(_target.position.x, _target.position.y, 0);

        targetPosition = targetPosition - transform.position;

        targetPosition.Normalize();
    }

    private void GotoPlayer()
    {
        _rigid.velocity = targetPosition * stats.chaseSpeed;
    }
}
