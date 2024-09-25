using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYLaserShoot : MGSYPattern
{
    [SerializeField] private Laser _laser;
    [SerializeField] private int _laserCount = 3;
    [SerializeField] private float _laserDelay = 0.03f;
    [SerializeField] private float _laserDamage = 5f;

    private void Awake()
    {
        Init(PatternTypeEnum.LaserShoot, this);
        _laser = transform.GetComponentInChildren<Laser>();
    }

    private void OnEnable()
    {
        mgsy.OnShootLaser += PatternStart;
    }

    private void OnDisable()
    {
        mgsy.OnShootLaser -= PatternStart;
    }

    public override void PatternStart()
    {
        mgsy.patternRoutine = StartCoroutine(MGSYLaserShootRoutine());
    }

    private IEnumerator MGSYLaserShootRoutine()
    {
        for (int i = 0; i < _laserCount; i++)
        {
            _laser.ActivateLaser(_laserDelay);
            MGSYLaserDamage(_laserDamage);
            yield return new WaitForSeconds(_laserDelay);
        }
        
    }


    private void MGSYLaserDamage(float damage)
    {
        for (int i = 0; i < _laser._lineRenderer.positionCount - 1; i++)
        {
            Vector3 start = _laser._lineRenderer.GetPosition(i);
            Vector3 end = _laser._lineRenderer.GetPosition(i + 1);

            RaycastHit2D hit = Physics2D.Linecast(start, end);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Health health = hit.collider.GetComponent<Health>();
                    if (health != null)
                    {
                        health.TakeDamage(damage, Vector2.zero, 0);
                    }
                }
            }
        }
    }

}
