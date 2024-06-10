using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private PlayerSkill _playerSkill;

    private float _speed;
    
    public static PlayerMovement instance;

    private void OnEnable()
    {
        _playerSkill.OnChangeSpeed += ChangeSpeed;
    }

    private void OnDisable()
    {
        _playerSkill.OnChangeSpeed -= ChangeSpeed;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
        _playerSkill = GetComponent<PlayerSkill>();
    }

    private void Start()
    {
        _speed = _playerSkill._currentSpeed;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void ChangeSpeed()
    {
        _speed = _playerSkill._currentSpeed;
    }

    private void PlayerMove()
    {
        _rigid.velocity = _playerInput.moveDir.normalized * _speed;
    }

    public void FaceDirection(Vector2 mousePos)
    {
        _spriteRenderer.flipX = transform.position.x > mousePos.x;
    }
}
