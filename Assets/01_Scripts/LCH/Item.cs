 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    Rigidbody2D _rigid;

    [SerializeField] private LayerMask isGround;
    [SerializeField] private float _timer;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _rigid.gravityScale = 0F;
            float y = 2 + 0.25f * Mathf.Sin(Time.time * _timer);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

        }
    }
}
