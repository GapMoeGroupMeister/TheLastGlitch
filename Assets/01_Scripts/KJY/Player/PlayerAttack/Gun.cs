using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    [SerializeField] private AttackPassiveFeedBack _attackPassiveFeedback;

    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _gunParent;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePos;
    private Animator _anim;

    [SerializeField] private int _bulletCount = 6;

    private bool _isShootCool = false;
    [SerializeField] private bool _isReloading = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();   
        _input.OnAttackEvent += TryFire;
    }

    private void OnEnable()
    {
        _isReloading = false;
    }

    private void TryFire()
    {
        if (_gunParent.activeSelf == true)
        {
            if (_bulletCount > 0)
            {
                if (!_isShootCool)
                {
                    Fire();
                    Debug.Log("Fire");
                }

            }
            if (_bulletCount == 0)
            {
                if (!_isReloading)
                {
                    StartCoroutine(ReloadGun());
                    _anim.SetBool("Reload", true);
                }
            }
        }
    }

    private void Fire()
    {
        _bulletCount--;
        GameObject bullet = InstantiateBullet();

        bullet.transform.SetPositionAndRotation(_firePos.position, _firePos.rotation);
        bullet.GetComponent<Bullet>().OnAttackEvent.AddListener(_attackPassiveFeedback.PlayFeedback);
        StartCoroutine(ShootCoolTime());
    }

    private IEnumerator ReloadGun()
    {
        _isReloading = true;
        yield return new WaitForSeconds(2f);
        _isReloading = false;
        _bulletCount = 6;
        _anim.SetBool("Reload", false);
    }

    private IEnumerator ShootCoolTime()
    {
        _isShootCool = true;
        yield return new WaitForSeconds(0.5f);
        _isShootCool = false;
    }

    private GameObject InstantiateBullet()
    {
        return Instantiate(_bulletPrefab);
    }

}
