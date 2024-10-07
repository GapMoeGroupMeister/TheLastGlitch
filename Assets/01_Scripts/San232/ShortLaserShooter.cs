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
        _laser.gameObject.SetActive(false);
    }

    public void FireLaser(Transform firePos, Transform target)
    {
        _laser.gameObject.SetActive(true);


        // ������ ��ġ ����
        _laser.SetLaserPositions(firePos.position, target.position);
        _laser.ActivateLaser(firePos.position, target.position, _laserDuration, _laserLifetime); // ������ �߻�
    }
}
