using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private float _desiredAngle;
    private bool _isAttack = false;
    private float _attackCoolTime = 0f;

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
        _desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg + 30f;
        //AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(_desiredAngle, Vector3.forward);
    }

    public void Attack()
    {
        if(!_isAttack) 
        {
            print("dd");
            StartCoroutine(RotationWeapon());
            _isAttack = false;
            _attackCoolTime = 0f;
        }
    }

    private IEnumerator RotationWeapon()
    {
        _isAttack = true;
        Vector3 rotate1 = new Vector3(0f, 0f, _desiredAngle - 30f);
        Vector3 rotate2 = new Vector3(0f, 0f, _desiredAngle - 50f);
        Quaternion rotation1 = Quaternion.Euler(rotate1);
        Quaternion rotation2 = Quaternion.Euler(rotate2);
        transform.rotation = Quaternion.Lerp(rotation1, rotation2, 4f / _attackCoolTime);
        _attackCoolTime += 60 * Time.deltaTime;
        yield return new WaitForSeconds(Time.deltaTime);

    }

    
}
