using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    private Laser _laser;
    private ShortLaser _shortLaser;

    [Header("Short Laser Check")]
    [SerializeField] private bool _isUseShortLaser = false;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.2f; // �������� Ÿ�ٿ� �����ϴ� �ð�
    [SerializeField] private float _laserLifetime = 0.3f; // �������� �����Ǵ� �ð�

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

            // ��ǥ ������ ����մϴ�.
            Vector3 direction = (target.position - firePos.position).normalized;

            // ������ ��ġ ����
            _shortLaser.SetLaserPositions(firePos.position, direction);
            _shortLaser.ActivateLaser(firePos.position, direction, _laserDuration, _laserLifetime); // ������ �߻�
        }
        else
        {
            _laser.gameObject.SetActive(true);

            // ��ǥ ������ ����մϴ�.
            Vector3 direction = (target.position - firePos.position).normalized;

            // ������ ��ġ ����
            _laser.SetLaserPositions(firePos.position, direction);
            _laser.ActivateLaser(firePos.position, direction, _laserDuration, _laserLifetime); // ������ �߻�
        }
    }
}
