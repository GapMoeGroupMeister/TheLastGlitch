using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLaserShooter : MonoBehaviour
{
    [SerializeField] private ShortLaser _laser;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.2f; // 레이저가 타겟에 도달하는 시간
    [SerializeField] private float _laserLifetime = 0.3f; // 레이저가 유지되는 시간

    private void Awake()
    {
        _laser = GetComponentInChildren<ShortLaser>();
        _laser.gameObject.SetActive(false);
    }

    public void FireLaser(Transform firePos, Transform target)
    {
        _laser.gameObject.SetActive(true);


        // 레이저 위치 설정
        _laser.SetLaserPositions(firePos.position, target.position);
        _laser.ActivateLaser(firePos.position, target.position, _laserDuration, _laserLifetime); // 레이저 발사
    }
}
