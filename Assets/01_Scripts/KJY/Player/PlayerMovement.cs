using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody2D _rigid;

    [SerializeField] private float _currentSpeed = 6f;
    [SerializeField] private float _normalSpeed = 6f;
    [SerializeField] private float _runSpeed = 10f;

    private bool _frenzyCoolTime = false;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.OnRunPressed += RunSpeed;
    }

    private void OnDisable()
    {
        _playerInput.OnRunPressed -= RunSpeed;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        _rigid.velocity = _playerInput.moveDir.normalized * _currentSpeed;
    }

    private void RunSpeed()
    {
        if (!_frenzyCoolTime)
        {
            StartCoroutine(FrenzySkill());
        }
    }

    private IEnumerator FrenzySkill()
    {
        _currentSpeed = _runSpeed;
        yield return new WaitForSeconds(2f);
        _currentSpeed = _normalSpeed;
        _frenzyCoolTime = true;
        yield return new WaitForSeconds(4f);
        _frenzyCoolTime = false;
    }
}
