using System.Collections;
using UnityEngine;

public class MGSYLaserShoot : MGSYPattern
{
    [SerializeField] private int _laserCount = 3; // 발사할 레이저 수
    [SerializeField] private Laser _laser;
    [SerializeField] private float _laserDelay = 2f; // 레이저 사이의 딜레이
    [SerializeField] private float _laserDamage = 5f;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private Transform _firePos;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 0.3f; // 레이저가 타겟에 도달하는 시간
    [SerializeField] private float _laserLifetime = 1f; // 레이저가 유지되는 시간

    protected override void Awake()
    {
        base.Awake();
        Init(PatternTypeEnum.LaserShoot);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerTrm = player.transform;
        _laser.SetLaserPositions(_firePos.position, _playerTrm.position);
    }

    private void OnEnable()
    {
        mgsy.OnShootLaser += BlastLaserOnce;
    }

    private void OnDisable()
    {
        mgsy.OnShootLaser -= BlastLaserOnce;
    }

    public override void PatternStart()
    {
        mgsy.StateMachine.ChangeState(BossStateEnum.Shooting);
    }

    public override void PatternEnd()
    {
        mgsy.StopPatterns();
        if (_laserCount == 0)
        {
            mgsy.StateMachine.ChangeState(BossStateEnum.Closing);
        }
    }

    private void BlastLaserOnce()
    {
        if (_laserCount > 0)
        {
            mgsy.patternRoutine = StartCoroutine(MGSYLaserShootRoutine());
        }
    }

    private IEnumerator MGSYLaserShootRoutine()
    {
        // 레이저 발사
        _laser.SetLaserPositions(_firePos.position, _playerTrm.position);
        _laser.ActivateLaser(_firePos.position, _playerTrm.position, _laserDuration, _laserLifetime);
        MGSYLaserDamage(_laserDamage);

        yield return new WaitForSeconds(_laserDelay); // 딜레이 설정

        _laserCount--; // 레이저 카운트 감소
        if (_laserCount == 0)
        {
            PatternEnd(); // 레이저 카운트가 0일 때 패턴 종료
        }
    }

    private void MGSYLaserDamage(float damage)
    {
        for (int i = 0; i < _laser._lineRenderer.positionCount - 1; i++)
        {
            Vector3 start = _laser._lineRenderer.GetPosition(i);
            Vector3 end = _laser._lineRenderer.GetPosition(i + 1);

            RaycastHit2D hit = Physics2D.Linecast(start, end);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
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
