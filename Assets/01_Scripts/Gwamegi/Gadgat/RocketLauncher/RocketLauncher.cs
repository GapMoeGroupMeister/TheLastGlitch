using Cinemachine;
using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab; // ���� ������
    public Transform launchPoint;   // ���� �߻� ��ġ
    public float launchForce = 500f; // �߻� ��
    public float duration = 5f; // ���� ���� �ð�
    public Vector3 controlPoint1; // Bezier � ������ 1
    public Vector3 controlPoint2; // Bezier � ������ 2

    [SerializeField] private CinemachineVirtualCamera ShootCamera;
    [SerializeField] private CinemachineVirtualCamera MainCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // ��Ŭ�� ����
        {
            ShootCamera.Priority = 1; MainCamera.Priority = 0;
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0)) // ��Ŭ�� ����
            {
                LaunchRocket();
                break;
            }
        }

        yield return new WaitForSeconds(duration);
        ShootCamera.Priority = 0; MainCamera.Priority = 1;
    }

    private void LaunchRocket()
    {
        //// Ŭ���� ��ġ ���
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ���� ����
        GameObject rocket = Instantiate(rocketPrefab, launchPoint.position, Quaternion.identity);
        RocketMovement movement = rocket.GetComponent<RocketMovement>();




        // ���� �ʱ�ȭ �� �߻�
        controlPoint1 = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-7.5f, 7.5f));


        controlPoint2 = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(0, 7.5f));

        print(controlPoint1);
        print(controlPoint2);


        Vector3 targetTrm = new Vector3(targetPosition.x + Random.Range(-1.5f,1.5f), targetPosition.y + Random.Range(-1.5f, 1.5f), targetPosition.z);


        movement.Initialize(launchPoint.position, controlPoint1, controlPoint2, targetTrm, duration);
        
    }
}
