using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MGSYLaserShoot : MGSYPattern
{
    [SerializeField] private int _laserCount = 3; // 발사할 레이저 수
    [SerializeField] private Laser _laser;
    [SerializeField] private float _laserDelay = 1f; // 레이저 사이의 딜레이
    [SerializeField] private int _laserDamage = 5;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private Transform _firePos;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 10f; // 레이저가 타겟에 도달하는 시간
    [SerializeField] private float _laserLifetime = 0.3f;  // 레이저가 유지되는 시간

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
            _laserCount = 3; // 다시 초기화
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
        Vector3 direction = (_playerTrm.position - _firePos.position).normalized;
        Vector3 endPosition = _firePos.position + direction * 1000f; // 레이저 길이 설정

        // 레이저 발사
        _laser.SetLaserPositions(_firePos.position, endPosition);
        _laser.ActivateLaser(_firePos.position, endPosition, _laserDuration, _laserLifetime);

        // 대미지 적용
        mgsy.DamageCasterCompo.CastDamge(_laserDamage, 2f);

        yield return new WaitForSeconds(_laserDelay); // 딜레이

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

            // Linecast를 Raycast로 변경하여, 좀 더 정확한 충돌 감지 수행
            RaycastHit2D[] hits = Physics2D.RaycastAll(start, (end - start).normalized, Vector3.Distance(start, end));

            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    Health health = hit.collider.GetComponent<Health>();
                    if (health != null)
                    {
                        health.TakeDamage(damage, Vector2.zero, 0); // 대미지 적용
                    }
                }
            }
        }
    }
}
