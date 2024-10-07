using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLaserShooter : MonoBehaviour
{
    [SerializeField] private ShortLaser _laser;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.2f; // �������� Ÿ�ٿ� �����ϴ� �ð�
    [SerializeField] private float _laserLifetime = 0.3f; // �������� �����Ǵ� �ð�

    private void Awake()
    {
        _laser = GetComponentInChildren<ShortLaser>();
    }

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
