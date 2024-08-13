using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;

    private void Awake()
    {
        _input.OnAttackEvent += Fire;
    }

    private void Fire()
    {
        Instantiate(_bulletPrefab, _firePos.position, Quaternion.identity);
    }

}
