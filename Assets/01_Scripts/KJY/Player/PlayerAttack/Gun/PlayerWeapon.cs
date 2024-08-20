using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    private float desiredAngle;
    private WeaponRenderer _weaponRenderer;

    private void Awake()
    {
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }

    private void Update()
    {
        AimWeapon();
    }

    public void AimWeapon()
    {
        Vector3 aimDir = (Vector3)_input.MousePos - transform.position;
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        AdjustWeaponRendering();
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
    }

    public void AdjustWeaponRendering()
    {
        _weaponRenderer.FlipWeapon(desiredAngle > 90 || desiredAngle < -90);
    }
}