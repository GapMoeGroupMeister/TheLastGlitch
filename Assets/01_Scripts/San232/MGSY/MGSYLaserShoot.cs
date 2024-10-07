using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MGSYLaserShoot : MGSYPattern
{
    [SerializeField] private int _laserCount = 3; // �߻��� ������ ��
    [SerializeField] private Laser _laser;
    [SerializeField] private float _laserDelay = 1f; // ������ ������ ������
    [SerializeField] private int _laserDamage = 5;
    [SerializeField] private Transform _playerTrm;
    [SerializeField] private Transform _firePos;

    [Header("Laser Settings")]
    [SerializeField] private float _laserDuration = 10f; // �������� Ÿ�ٿ� �����ϴ� �ð�
    [SerializeField] private float _laserLifetime = 0.3f;  // �������� �����Ǵ� �ð�

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
            _laserCount = 3; // �ٽ� �ʱ�ȭ
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
        Vector3 endPosition = _firePos.position + direction * 1000f; // ������ ���� ����

        // ������ �߻�
        _laser.SetLaserPositions(_firePos.position, endPosition);
        _laser.ActivateLaser(_firePos.position, endPosition, _laserDuration, _laserLifetime);

        // ����� ����
        mgsy.DamageCasterCompo.CastDamge(_laserDamage, 2f);

        yield return new WaitForSeconds(_laserDelay); // ������

        _laserCount--; // ������ ī��Ʈ ����
        if (_laserCount == 0)
        {
            PatternEnd(); // ������ ī��Ʈ�� 0�� �� ���� ����
        }
    }

    private void MGSYLaserDamage(float damage)
    {
        for (int i = 0; i < _laser._lineRenderer.positionCount - 1; i++)
        {
            Vector3 start = _laser._lineRenderer.GetPosition(i);
            Vector3 end = _laser._lineRenderer.GetPosition(i + 1);

            // Linecast�� Raycast�� �����Ͽ�, �� �� ��Ȯ�� �浹 ���� ����
            RaycastHit2D[] hits = Physics2D.RaycastAll(start, (end - start).normalized, Vector3.Distance(start, end));

            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    Health health = hit.collider.GetComponent<Health>();
                    if (health != null)
                    {
                        health.TakeDamage(damage, Vector2.zero, 0); // ����� ����
                    }
                }
            }
        }
    }
}
