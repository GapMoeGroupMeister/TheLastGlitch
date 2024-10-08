using System.Collections;
using UnityEngine;
using System.Linq;
using System;

public enum EnemyStateEnum
{
    Idle,
    Attack,
    Chase,
    Walk,
    Hit,
    Wait,
    Dead
}
public class Enemy : EnemySetting
{
    public Vector2 dir;
    public bool CanAttack = true;
    public bool FirstAttack = true;
    public bool Boom = false;
    public float distance;
    public bool FirstWake = true;
    public bool fainting = false;
    public Pooling _enemyPooling;
    public StateMachine<EnemyStateEnum> StateMachine { get; set; }

    [SerializeField] private Transform[] wayPoint;

    public void GetHit()
    {
        StateMachine.ChangeState(EnemyStateEnum.Hit);
    }

    public override void SetDeadState()
    {
        StateMachine.ChangeState(EnemyStateEnum.Dead);
    }
    protected override void Awake()
    {
        if (!IsDie)
            StateMachine = new StateMachine<EnemyStateEnum>();
        base.Awake();
    }

    private void Start()
    {
        StartCoroutine(MoveDealyCorotine());
    }

    private IEnumerator MoveDealyCorotine()
    {
        while (true)
        {
            dir = RandomVetcer() - transform.position;
            yield return new WaitForSeconds(2F);
            MovementComponent._xMove = 0f;
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnEnable()
    {
        StateMachine.InitInitialize(EnemyStateEnum.Idle, this);
        HealthComponent.Initialize(this);
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.UpdateState();

        if (GetPlayer())
        {
            MovementComponent._xMove = 0F;
        }
    }

    private void LateUpdate()
    {
        StateMachine.CurrentState.LateUpdateState();
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }
}