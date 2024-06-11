using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkill : MonoBehaviour
{
    public Action OnChangeSpeed;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigid;
    private float _dashDistance;

    private bool _frenzyCoolTime = false;
    private bool _dashCoolTime = false;
    private Vector2 _dashDirection;

    [SerializeField] private float _dashPower = 0f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _normalSpeed = 6f;
    public float _currentSpeed = 6f;

    private void Update()
    {
        
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
        _playerInput.OnFrenzyPressed += FrenzySkill;
        _playerInput.OnDashPressed += DashSkill;
    }

    private void OnDisable()
    {
        _playerInput.OnFrenzyPressed -= FrenzySkill;
        _playerInput.OnDashPressed -= DashSkill;
    }

    private void FrenzySkill()
    {
        if (!_frenzyCoolTime)
        {
            StartCoroutine(FrenzySkillCO());
            OnChangeSpeed.Invoke();
        }
    }

    private IEnumerator FrenzySkillCO()
    {
        _currentSpeed = _runSpeed;
        print("Run");
        yield return new WaitForSeconds(2f);
        _currentSpeed = _normalSpeed;
        print("Normal");
        OnChangeSpeed?.Invoke();
        _frenzyCoolTime = true;
        yield return new WaitForSeconds(4f);
        _frenzyCoolTime = false;
    }

    private void DashSkill()
    {
        if (!_dashCoolTime)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print("Pos");
        _dashDirection = (mousePos - (Vector2)transform.position).normalized;
        print("Dir");
        _rigid.AddForce(Vector2.down * _dashPower, ForceMode2D.Impulse);
        print("Add");
        _dashCoolTime = true;
        yield return new WaitForSeconds(2f);
        _rigid.velocity = Vector2.zero;
        _dashCoolTime = false;
    }
}