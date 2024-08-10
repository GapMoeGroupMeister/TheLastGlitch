using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalGun : MonoBehaviour
{
    protected Vector2 _redPotalTransform;
    protected Vector2 _bluePotalTransform;

    [SerializeField] private GameObject _bluePrefab;
    [SerializeField] private GameObject _redPrefab;

    private Vector2 _mousePos;

    public bool _isBluePotalFire = true;
    public bool isBluePortalCreate;

    private void Update()
    {

        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (_isBluePotalFire)
            GunWate();
    }

    private void GunWate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("��� ��Ż �߻�");

            StartCoroutine(BluePotalShat());

        }

    }

    private IEnumerator BluePotalShat()
    {
        GameObject bullet = Instantiate(_bluePrefab);
        bullet.transform.position = transform.position;

        _isBluePotalFire = false;


        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0) && isBluePortalCreate)
            {
                Debug.Log("���� ��Ż �߻�");

                RedPotalShat();
                break;
            }
        }

    }

    private void RedPotalShat()
    {
        GameObject bullet = Instantiate(_redPrefab);
        bullet.transform.position = transform.position;

        Destroy(gameObject);
        // �ʹ� ����ϰ� �������°� ����

    }
}
