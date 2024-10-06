using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private Laser _laser;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.2f; // �������� Ÿ�ٿ� �����ϴ� �ð�
    [SerializeField] private float _laserLifetime = 0.3f; // �������� �����Ǵ� �ð�

    public void FireLaser(Transform firePos, Transform target)
    {
        _laser.gameObject.SetActive(true);

        // ��ǥ ������ ����մϴ�.
        Vector3 direction = (target.position - firePos.position).normalized;

        // ������ ��ġ ����
        _laser.SetLaserPositions(firePos.position, direction);
        _laser.ActivateLaser(firePos.position, direction, _laserDuration, _laserLifetime); // ������ �߻�
    }
}
