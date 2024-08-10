using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotalBullet : PotalGunBullet
{
    public override void IsTeleporting()
    {
        GetComponent<Portal>()._teleportingPortal.gameObject.GetComponent<Portal>().isMy = true;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("���� ��Ż ���� ����");
            Debug.Log(transform.position + "��Ż ���� ��ġ");

            GameObject potal = Instantiate(_redPotalPrefab);
            potal.GetComponent<Portal>()._teleportingPortal = PotalManager.Instance._bluePortal;
            PotalManager.Instance._bluePortal.GetComponent<Portal>()._teleportingPortal = potal;
            potal.transform.position = transform.position;
            PotalManager.Instance._redPotalTranform = potal.transform.position;
            PotalManager.Instance.redPotal = potal.GetComponent<RedPotal>();
            Destroy(gameObject);
        }
    }
}
