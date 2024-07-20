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

    private bool _isBluePotalFire = true;

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
            Debug.Log("ºí·ç Æ÷Å» ¹ß»ç");

            StartCoroutine(BluePotalShat());
            _isBluePotalFire = false;

        }

    }

    private IEnumerator BluePotalShat()
    {
        GameObject bullet = Instantiate(_bluePrefab);
        bullet.transform.position = transform.position;



        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("·¹µå Æ÷Å» ¹ß»ç");

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
        // ÂÍ´õ ±ò·ÕÇÏ°Ô ¾ø¾îÁö´Â°Å ±¸Çö

    }
}
