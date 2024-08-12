using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.InputSystem.InputControlExtensions;

public class TestPlayer : Agent
{
    private Rigidbody2D _rigid;
    public float velocity;
    public float jumpPower;
    private float _xMove;
    [SerializeField] GameObject _drone;
    private Health Health;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        Health = GetComponent<Health>();
        Health.Initialize(this);

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
        if(_xMove != 0)
        {
            transform.localScale = new Vector3(_xMove, 1, 1);
        }
        UseGadget();
    }

    private void UseGadget()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            print(1);
            GameObject drone = Instantiate(_drone);
        }
    }

    public void Test()
    {
        Debug.Log("aa");
    }

    public override void SetDeadState()
    {
    }
}
