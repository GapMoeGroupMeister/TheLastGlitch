using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunTest : MonoBehaviour
{
    public GameObject portalPrefab; // ��Ż ������
    public Transform shootPoint; // ��Ż �߻� ����

    private GameObject portalA; // ù ��° ��Ż
    private GameObject portalB; // �� ��° ��Ż

    public bool isBlue;
    public bool isRed;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isBlue) // ��Ż A ����
        {
            CreatePortal(ref portalA);
            isBlue = true;
        }
        else if (Input.GetButtonDown("Fire2") && !isRed) // ��Ż B ����
        {
            CreatePortal(ref portalB);
            isRed = true;
        }

        if (portalA != null && portalB != null)
        {
            // ��Ż A�� B�� ���� ����
            Portal2D portalAScript = portalA.GetComponent<Portal2D>();
            Portal2D portalBScript = portalB.GetComponent<Portal2D>();
            portalAScript.linkedPortal = portalBScript;
            portalBScript.linkedPortal = portalAScript;
        }
    }

    void CreatePortal(ref GameObject portal)
    {
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, shootPoint.right);
        if (hit.collider != null)
        {
            if (portal != null)
            {
                Destroy(portal); // ���� ��Ż�� �ִٸ� ����
            }
            portal = Instantiate(portalPrefab, hit.point, Quaternion.identity);
        }
    }
}
