using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunTest : MonoBehaviour
{
    public GameObject portalPrefab; // 포탈 프리팹
    public Transform shootPoint; // 포탈 발사 지점

    private GameObject portalA; // 첫 번째 포탈
    private GameObject portalB; // 두 번째 포탈

    public bool isBlue;
    public bool isRed;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isBlue) // 포탈 A 생성
        {
            CreatePortal(ref portalA);
            isBlue = true;
        }
        else if (Input.GetButtonDown("Fire2") && !isRed) // 포탈 B 생성
        {
            CreatePortal(ref portalB);
            isRed = true;
        }

        if (portalA != null && portalB != null)
        {
            // 포탈 A와 B를 서로 연결
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
                Destroy(portal); // 기존 포탈이 있다면 삭제
            }
            portal = Instantiate(portalPrefab, hit.point, Quaternion.identity);
        }
    }
}
