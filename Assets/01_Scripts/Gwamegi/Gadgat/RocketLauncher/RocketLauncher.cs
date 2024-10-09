using Cinemachine;
using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform launchPoint;
    public float launchForce = 500f;
    public float duration = 5f;
    public Vector3 controlPoint1;
    public Vector3 controlPoint2;

    private bool isFirstAttack = true;

    [SerializeField] private int whileCount = 1;

    private void OnEnable()
    {
        UseRocketLauncher();
    }

    private void LateUpdate()
    {
        transform.position = GameManager.Instance.player.transform.position;
        GetComponentInChildren<Transform>().position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void UseRocketLauncher()
    {
        if (isFirstAttack)
        {
            isFirstAttack = false;
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
            if (Input.GetMouseButtonDown(0))
            {
                LaunchRocket();
                break;
            }
        }
    }

    private void LaunchRocket()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RocketMovement rockePrefab = PoolManager.Instance.Pop("Rocket") as RocketMovement;
        Debug.Log("นึ");
        GameObject rocket = rockePrefab.gameObject;
        rocket.SetActive(true);

        RocketMovement movement = rocket.GetComponent<RocketMovement>();

        Vector3 target = targetPosition - launchPoint.position;

        controlPoint1 = new Vector3(target.x + Random.Range(-7.5f, 4f), target.y - Random.Range(-7.5f, 4f));
        controlPoint2 = new Vector3(target.x + Random.Range(-7.5f, 4f), target.y - Random.Range(0, 7.5f));

        Vector3 targetTrm = new Vector3(targetPosition.x + Random.Range(-0.75f, 0.75f), targetPosition.y + Random.Range(-0.75f, 0.75f), targetPosition.z);

        movement.Initialize(launchPoint.position, controlPoint1, controlPoint2, targetTrm, duration);

        Destroy(gameObject);
    }
}