using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private Laser _laser;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.2f; // 레이저가 타겟에 도달하는 시간
    [SerializeField] private float _laserLifetime = 0.3f; // 레이저가 유지되는 시간

    public void FireLaser(Transform firePos, Transform target)
    {
        _laser.gameObject.SetActive(true);

        // 목표 방향을 계산합니다.
        Vector3 direction = (target.position - firePos.position).normalized;

        // 레이저 위치 설정
        _laser.SetLaserPositions(firePos.position, direction);
        _laser.ActivateLaser(firePos.position, direction, _laserDuration, _laserLifetime); // 레이저 발사
    }
}
