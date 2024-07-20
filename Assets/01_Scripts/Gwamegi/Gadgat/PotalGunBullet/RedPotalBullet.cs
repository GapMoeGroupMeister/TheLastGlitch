using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotalBullet : PotalGunBullet
{

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("레드 포탈 생성 내부");
            Debug.Log(transform.position + "포탈 생성 위치");

            GameObject potal = Instantiate(_redPotalPrefab);
            potal.transform.position = transform.position;
            PotalManager.Instance._redPotalTranform = potal.transform.position;
            PotalManager.Instance.redPotal = potal.GetComponent<RedPotal>();
            Destroy(gameObject);
        }
    }
}
