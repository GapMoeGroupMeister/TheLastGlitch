using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingBullet : MonoBehaviour, Ipoolable
{
    public string ItemName => "GatlingBullet";
    private Rigidbody2D _rb;
    public Vector2 pos;
    private GameObject drone;
    private GatlingDrone droneCompo;
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    [SerializeField] float _knockBack;

    public GameObject ObjectPrefab => gameObject;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        drone = FindObjectOfType<GatlingDrone>().gameObject;
        droneCompo = drone.GetComponent<GatlingDrone>();
    }

    private void FixedUpdate()
    {
        BulletMove(droneCompo.target.transform.position);
    }

    public void BulletMove(Vector2 target)
    {
        _rb.velocity = target - (Vector2)transform.position.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
            health.TakeDamage(_damage, collision.transform.position.normalized, collision.transform.position, _knockBack);
        PoolManager.Instance.Push(this);
    }

    public void ResetItem()
    {
        transform.position = drone.transform.position ;
    }
}
