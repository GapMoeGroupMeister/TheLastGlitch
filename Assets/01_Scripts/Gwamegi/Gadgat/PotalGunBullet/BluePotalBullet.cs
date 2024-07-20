using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotalBullet : PotalGunBullet
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("블루 포탈 생성 내부");
            Debug.Log(transform.position + "포탈 생성 위치");
            GameObject potal = Instantiate(_bluePotalPrefab);
            potal.transform.position = transform.position;
            PotalManager.Instance._bluePotalTranform = potal.transform.position;
            PotalManager.Instance.bluePotal = potal.GetComponent<BluePotal>();

            Destroy(gameObject);
        }
    }
}
