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

    public bool _isBluePortalFire = false; // �ʱ⿡�� ��Ȱ��ȭ
    public bool isBluePortalCreate;

    private void Start()
    {
        //_type = GadgetType.portalGun; // PortalGun�� Ÿ�� ����
        _isUse += UsePortalGun; // UseGadget() �Լ� ȣ�� �� UsePortalGun() �Լ� ����
    }

    private void UsePortalGun()
    {
        _isBluePortalFire = true; // ���� ��� �� ��Ż �߻� Ȱ��ȭ
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
            Debug.Log("��� ��Ż �߻�");

            StartCoroutine(BluePortalShot());
        }
    }

    private IEnumerator BluePortalShot()
    {
        GameObject bullet = Instantiate(_bluePrefab);
        bullet.transform.position = transform.position;

        _isBluePortalFire = false; // ��� ��Ż �߻� �� ��Ȱ��ȭ

        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0) && isBluePortalCreate)
            {
                Debug.Log("���� ��Ż �߻�");

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