using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private Laser _laser;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.3f; // 레이저가 타겟에 도달하는 시간
    [SerializeField] private float _laserLifetime = 1f; // 레이저가 유지되는 시간

    public void FireLaser(Transform firePos, Transform target)
    {
        _laser.gameObject.SetActive(true);
        _laser.SetLaserPositions(firePos.position, target.position);
        _laser.ActivateLaser(firePos.position, target.position, _laserDuration, _laserLifetime); // 레이저 발사
    }
}
