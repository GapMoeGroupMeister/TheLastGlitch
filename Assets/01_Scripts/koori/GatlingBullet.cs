using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingBullet : MonoBehaviour, Ipoolable
{
    public string ItemName => "GatlingBullet";
    private Rigidbody2D _rb;
    public Vector2 pos;
    private GameObject _drone;
    private Vector3 _dir;
    private GatlingDrone droneCompo;
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    [SerializeField] float _knockBack;

    public GameObject ObjectPrefab => gameObject;


    private void OnEnable()
    {
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _drone = FindObjectOfType<GatlingDrone>().gameObject;
        droneCompo = _drone.GetComponent<GatlingDrone>();
    }

    private void FixedUpdate()
    {
        if (droneCompo.target == null)
        {
            PoolManager.Instance.Push(this);
            return;
        }

        _rb.velocity = _dir * _speed;
        Debug.Log(_dir);

    }

    public void BulletMove(Vector2 target)
    {
        pos = target;
        _dir = pos - (Vector2)transform.position;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            Debug.Log("Take Damage");
            health.TakeDamage(_damage, -collision.transform.position.normalized, collision.transform.position, _knockBack);
            PoolManager.Instance.Push(this);

        }
    }

    public void ResetItem()
    {
        transform.position = _drone.transform.position;
        BulletMove(droneCompo.target.transform.position);
        
    }
}
