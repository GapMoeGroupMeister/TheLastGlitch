using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotalBullet : PotalGunBullet
{
    public override void IsTeleporting()
    {
        GetComponent<Portal>()._teleportingPortal.gameObject.GetComponent<Portal>().isMy = true;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("��� ��Ż ���� ����");
            Debug.Log(transform.position + "��Ż ���� ��ġ");
            PotalManager.Instance._bluePortal = Instantiate(_bluePotalPrefab);
            PotalManager.Instance._bluePortal.transform.position = transform.position;
            PotalManager.Instance._bluePotalTranform = PotalManager.Instance._bluePortal.transform.position;
            PotalManager.Instance.bluePotal = PotalManager.Instance._bluePortal.GetComponent<Portal>();
            FindAnyObjectByType<PortalGun>().isBluePortalCreate = true;
            Destroy(gameObject);
        }
    }
}
