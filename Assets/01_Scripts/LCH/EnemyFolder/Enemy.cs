using System.Collections;
using UnityEngine;

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

public enum BossStateEnum
{
    Idle,
    Closed,
    Opened,
    AngryOpened,
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
        if(!IsDie)
        StateMachine = new StateMachine<EnemyStateEnum>();
        base.Awake();
    }

    protected virtual void Start()
    {
        StateMachine.InitInitialize(EnemyStateEnum.Idle, this);
        StartCoroutine(Delaytime());
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    private void LateUpdate()
    {
        StateMachine.CurrentState.LateUpdateState();
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }

    protected IEnumerator Delaytime()
    {
        if (!IsDie)
        {
            while (true)
            {
                dir = GetRandomVector() - transform.position;
                yield return new WaitForSeconds(2f);
                dir = Vector2.zero;
                yield return new WaitForSeconds(2f);
            }
        }

    }

}
