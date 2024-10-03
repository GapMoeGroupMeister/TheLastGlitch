using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private Laser _laser;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.3f; // �������� Ÿ�ٿ� �����ϴ� �ð�
    [SerializeField] private float _laserLifetime = 1f; // �������� �����Ǵ� �ð�

    public void FireLaser(Transform firePos, Transform target)
    {
        _laser.gameObject.SetActive(true);
        _laser.SetLaserPositions(firePos.position, target.position);
        _laser.ActivateLaser(firePos.position, target.position, _laserDuration, _laserLifetime); // ������ �߻�
    }
}
