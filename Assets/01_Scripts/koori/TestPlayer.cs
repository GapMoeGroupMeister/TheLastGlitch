using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.InputSystem.InputControlExtensions;

public class TestPlayer : MonoBehaviour
{
    private Rigidbody2D _rigid;
    public float velocity;
    public float jumpPower;
    private float _xMove;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _xMove = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(_xMove) > 0)
        {
            _rigid.velocity = new Vector2(_xMove * velocity, _rigid.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpPower);
        }
    }
}
