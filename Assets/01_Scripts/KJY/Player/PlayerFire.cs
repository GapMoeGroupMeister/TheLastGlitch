using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFire : MonoBehaviour
{
    private float _maxDesiredAngle = 90f;
    private float _desiredAngle;
    private bool _isAttack = false;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.OnFireButton += Attack;
    }

    private void OnDisable()
    {
        _playerInput.OnFireButton -= Attack;
    }

    public void AimWeapon(Vector2 pointerPos)
    {
        Vector3 aimDir = (Vector3)pointerPos - transform.position;
        _desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg + 50f;
        transform.rotation = Quaternion.AngleAxis(_desiredAngle, Vector3.forward);
    }

    public void Attack()
    {
        if(!_isAttack) 
        {
            print("dd");
            StartCoroutine(RotationWeapon());
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DORotate(new Vector3(0f, 0f, _desiredAngle - _maxDesiredAngle), 0.2f));
            sequence.Append(transform.DORotate(new Vector3(0f, 0f, _desiredAngle), 0.1f));
            sequence.Play();
        }
    }

    private IEnumerator RotationWeapon()
    {
        _isAttack = true;
        yield return new WaitForSeconds(0.3f);
        _isAttack = false;
    }

    
}
