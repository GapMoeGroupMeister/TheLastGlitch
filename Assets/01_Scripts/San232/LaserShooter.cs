using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    private Laser _laser;
    private ShortLaser _shortLaser;

    [Header("Short Laser Check")]
    [SerializeField] private bool _isUseShortLaser = false;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.2f; // 레이저가 타겟에 도달하는 시간
    [SerializeField] private float _laserLifetime = 0.3f; // 레이저가 유지되는 시간

    private void Awake()
    {
        if(_isUseShortLaser)
            _shortLaser = GetComponentInChildren<ShortLaser>(); 
        else
            _laser = GetComponentInChildren<Laser>();
    }

    public void FireLaser(Transform firePos, Transform target)
    {
        if( _isUseShortLaser)
        {
            _shortLaser.gameObject.SetActive(true);

            // 목표 방향을 계산합니다.
            Vector3 direction = (target.position - firePos.position).normalized;

            // 레이저 위치 설정
            _shortLaser.SetLaserPositions(firePos.position, direction);
            _shortLaser.ActivateLaser(firePos.position, direction, _laserDuration, _laserLifetime); // 레이저 발사
        }
        else
        {
            _laser.gameObject.SetActive(true);

            // 목표 방향을 계산합니다.
            Vector3 direction = (target.position - firePos.position).normalized;

            // 레이저 위치 설정
            _laser.SetLaserPositions(firePos.position, direction);
            _laser.ActivateLaser(firePos.position, direction, _laserDuration, _laserLifetime); // 레이저 발사
        }
    }
}
