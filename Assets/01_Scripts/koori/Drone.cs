using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drone : MonoBehaviour
{
    protected float detectRadius;
    protected float speed;
    protected Rigidbody2D _rdCompo;
    public Collider2D target;
    [SerializeField] private LayerMask enemyLayer;
    private LchTestPlayer _player;
    private void Awake()
    {
        _rdCompo = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        DroneMove();
    }

    private void DroneMove()
    {
        Vector2 pos = (Vector2)PlayerManager.instance.Player.transform.position + new Vector2(-1.5f, 1.8f);
        Vector2 dis = pos - (Vector2)transform.position;
        _rdCompo.velocity = dis.normalized * speed;
    }

    public virtual void Update()
    {
        Detect();
    }
    protected abstract void Attack();
    private void Detect()
    {
        target = Physics2D.OverlapCircle(transform.position + new Vector3(2.5f, -2.5f, 0), detectRadius, enemyLayer);
        if (target != null)
        {
            Attack();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(2, -2.5f, 0), detectRadius);
    }
}
