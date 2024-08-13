using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field : SerializeField] private InputReader _input;
    [SerializeField] private float _bulletSpeed = 8f;

    private Rigidbody2D _rigid;

    private bool _shot = false;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!_shot)
        {
            if (_input.MousePos.x < 0)
            {
                _rigid.velocity = Vector2.left * _bulletSpeed;
                _shot = true;
                StartCoroutine(BulletActive());
            }
            else if (_input.MousePos.x > 0)
            {
                _rigid.velocity = Vector2.right * _bulletSpeed;
                _shot = true;
                StartCoroutine(BulletActive());
            }
        }
    }

    private IEnumerator BulletActive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
