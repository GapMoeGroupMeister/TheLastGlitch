using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : GadgetParent
{
    protected Vector2 _redPortalTransform;
    protected Vector2 _bluePortalTransform;

    [SerializeField] private GameObject _bluePrefab;
    [SerializeField] private GameObject _redPrefab;

    private Vector2 _mousePos;

    public bool _isBluePortalFire = false; // 초기에는 비활성화
    public bool isBluePortalCreate;

    private void Start()
    {
        //_type = GadgetType.portalGun; // PortalGun의 타입 설정
        _isUse += UsePortalGun; // UseGadget() 함수 호출 시 UsePortalGun() 함수 실행
    }

    private void UsePortalGun()
    {
        _isBluePortalFire = true; // 가젯 사용 시 포탈 발사 활성화
    }

    private void Update()
    {
        if (_isBluePortalFire)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GunWait();
        }
    }

    private void GunWait()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("블루 포탈 발사");

            StartCoroutine(BluePortalShot());
        }
    }

    private IEnumerator BluePortalShot()
    {
        GameObject bullet = Instantiate(_bluePrefab);
        bullet.transform.position = transform.position;

        _isBluePortalFire = false; // 블루 포탈 발사 후 비활성화

        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0) && isBluePortalCreate)
            {
                Debug.Log("레드 포탈 발사");

                RedPortalShot();
                break;
            }
        }
    }

    private void RedPortalShot()
    {
        GameObject bullet = Instantiate(_redPrefab);
        bullet.transform.position = transform.position;

        Destroy(gameObject);
    }
}