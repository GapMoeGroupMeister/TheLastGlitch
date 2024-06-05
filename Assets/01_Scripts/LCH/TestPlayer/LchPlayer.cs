using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LchPlayer : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private float _speed = 5f;
    private bool waitIsGanghwajang = false;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);
        _rigid.velocity = move.normalized * _speed;
    }

    private void CheckGanghwajang()
    {

    }
}
