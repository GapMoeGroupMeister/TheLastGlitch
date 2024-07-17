using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructDrone : Drone
{
    private Rigidbody2D _rb;
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;
    [SerializeField] int _damage;
    [SerializeField] float _knockBack;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    protected override void Attack()
    {
        if (target != null)
        {
            automove = false;
            _rb.velocity = (target.transform.position - transform.position).normalized * _speed;
        }
        else
            automove = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage, -collision.transform.position.normalized, collision.transform.position, _knockBack);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Debug.Log("Æã!");
    }
}
