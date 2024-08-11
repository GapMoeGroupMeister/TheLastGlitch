using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{

    [Header("Reference")]
    [SerializeField] private Transform _groundCheckerTrm;
    [Header("Settings")]
    public float moveSpeed = 5f;
    public float jumpPower = 7f;
    public float extraGravity = 30f;
    public float gravityDelay = 0.15f;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Vector2 _groundCheckerSize;
    public Rigidbody2D rbCompo { get; private set; }
    public NotifyValue<bool> isGround = new NotifyValue<bool>();
    public float _xMove;
    private float _timeInAir;
    private Agent _owner;
    public float knockbackTime = 0.2f;
    public bool _canMove = true;
    protected Coroutine _kbCoroutine;
    public void Initialize(Agent agent)
    {
        _owner = agent;
        rbCompo = GetComponent<Rigidbody2D>();
    }
    public void JumpTo(Vector2 force)
    {
        SetMovement(force.x);
        rbCompo.AddForce(force, ForceMode2D.Impulse);
    }
    public void SetMovement(float xMove)
    {
        _xMove = xMove;
    }
    public void StopImmediately(bool isYStop = false)
    {
        if (isYStop)
        {
            rbCompo.velocity = Vector2.zero;
        }
        else
        {
            rbCompo.velocity = new Vector2(0, rbCompo.velocity.y);
        }
    }
    public void Jump(float multiplier = 1f)
    {
        _timeInAir = 0;
        rbCompo.velocity = Vector2.zero;
        rbCompo.AddForce(Vector2.up * jumpPower * multiplier, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (!isGround.Value)
        {
            _timeInAir += Time.deltaTime;
        }
        else
        {
            _timeInAir = 0;
        }

    }
    private void FixedUpdate()
    {
        CheckGrounded();
        ApplyExtraGravity();

        ApplyXMovement();
    }

    private void ApplyXMovement()
    {
        if (_canMove == false) return;

        rbCompo.velocity = new Vector2(_xMove * moveSpeed, rbCompo.velocity.y);
    }

    public bool CheckGrounded()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundCheckerTrm.position, _groundCheckerSize, 0, _whatIsGround);
        isGround.Value = collider != null;
        return collider;
    }
    private void ApplyExtraGravity()
    {
        if (_timeInAir > gravityDelay)
            rbCompo.AddForce(new Vector2(0, -extraGravity));
    }

    #region Knockback Region
    public void GetKnockback(Vector3 direction, float power)
    {
        Vector3 difference = direction * power * rbCompo.mass;
        rbCompo.AddForce(difference, ForceMode2D.Impulse);

        if (_kbCoroutine != null)
            StopCoroutine(_kbCoroutine);

        _kbCoroutine = StartCoroutine(KnockbackCoroutine());
    }

    private IEnumerator KnockbackCoroutine()
    {
        Debug.Log(_kbCoroutine);
        _canMove = false;
        yield return new WaitForSeconds(knockbackTime);
        ClearKnockback();
    }

    public void ClearKnockback()
    {
        rbCompo.velocity = Vector2.zero;
        _canMove = true;
    }
    #endregion

#if UNITY_EDITOR    
    private void OnDrawGizmosSelected()
    {
        if (_groundCheckerTrm == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundCheckerTrm.position, _groundCheckerSize);
        Gizmos.color = Color.white;
    }
#endif
}
