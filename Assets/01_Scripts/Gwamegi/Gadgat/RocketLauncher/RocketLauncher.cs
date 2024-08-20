using Cinemachine;
using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab; // 로켓 프리팹
    public Transform launchPoint;   // 로켓 발사 위치
    public float launchForce = 500f; // 발사 힘
    public float duration = 5f; // 궤적 지속 시간
    public Vector3 controlPoint1; // Bezier 곡선 제어점 1
    public Vector3 controlPoint2; // Bezier 곡선 제어점 2

    private bool isFristAttack = true;

    [SerializeField] private int whileCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isFristAttack) // 좌클릭 감지
        {
            isFristAttack = false;
            for (int i = 0; i < whileCount; i++)
            {
                StartCoroutine(Shoot());
            }
        }


    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return null;
            if (Input.GetMouseButtonDown(0)) // 좌클릭 감지
            {
                LaunchRocket();
                break;
            }
        }
    }

    private void LaunchRocket()
    {
        //// 클릭한 위치 계산
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 로켓 생성
        RocketMovement rockePrefab = PoolManager.Instance.Pop("Rocket") as RocketMovement;
        Debug.Log("밍");
        GameObject rocket = rockePrefab.gameObject;
        rocket.SetActive(true);

        RocketMovement movement = rocket.GetComponent<RocketMovement>();



        Vector3 target = targetPosition - launchPoint.position;

        // 로켓 초기화 및 발사
        controlPoint1 = new Vector3(target.x + Random.Range(-7.5f, 4f), target.y - Random.Range(-7.5f, 4f));


        controlPoint2 = new Vector3(target.x + Random.Range(-7.5f, 4f), target.y - Random.Range(0, 7.5f));




        Vector3 targetTrm = new Vector3(targetPosition.x + Random.Range(-0.75f, 0.75f), targetPosition.y + Random.Range(-0.75f, 0.75f), targetPosition.z);


        movement.Initialize(launchPoint.position, controlPoint1, controlPoint2, targetTrm, duration);

        Destroy(gameObject);

    }
}
