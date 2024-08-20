using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] private Laser _laser;
    [SerializeField] private float _laserTime = 0.3f;

    private void Awake()
    {
        _laser = transform.gameObject.GetComponent<Laser>();
    }

    public void FireLaser(Transform firePos, Transform target)
    {
        _laser.SetLaserPositions(firePos.position, target.position);
        _laser.ActivateLaser(_laserTime);
    }
}