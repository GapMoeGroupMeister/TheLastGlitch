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
            GameObject bullet = InstantiateBullet();

            bullet.transform.SetPositionAndRotation(_firePos.position, _firePos.rotation);
        }
    }

    private GameObject InstantiateBullet()
    {
        return Instantiate(_bulletPrefab);
    }

}
