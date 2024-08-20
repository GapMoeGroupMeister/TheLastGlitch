using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _gunParent;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;

    private bool _isShootCool = false;

    private void Awake()
    {
        _input.OnAttackEvent += Fire;
    }

    private void Start()
    {

    }

    private void Fire()
    {
        if (_gunParent.activeSelf == true)
        {
            if (!_isShootCool)
            {
                GameObject bullet = InstantiateBullet();

                bullet.transform.SetPositionAndRotation(_firePos.position, _firePos.rotation);
                StartCoroutine(ShootCoolTime());
            }
        }
    }

    private IEnumerator ShootCoolTime()
    {
        _isShootCool = true;
        yield return new WaitForSeconds(1f);
        _isShootCool = false;
    }

    private GameObject InstantiateBullet()
    {
        return Instantiate(_bulletPrefab);
    }

}
