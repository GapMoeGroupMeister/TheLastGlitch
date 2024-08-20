using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field : SerializeField] private InputReader _input;
    [SerializeField] private float _bulletSpeed = 8f;

    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _knockBackPower = 10f;


    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigid.velocity = transform.right * _bulletSpeed;

        StartCoroutine(BulletActive());
    }

    private IEnumerator BulletActive()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Vector2 attackDir = new Vector2(Mathf.Clamp(Vector3.Cross(collision.gameObject.transform.position, transform.position).z, -1, 1), 0);
                collision.gameObject.GetComponent<Health>().TakeDamage(_damage, -attackDir, _knockBackPower);
            }
        }
    }
}
