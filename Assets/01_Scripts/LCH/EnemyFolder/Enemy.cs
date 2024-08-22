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
    
    public StateMachine<EnemyStateEnum> StateMachine { get; private set; }

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
        base.Awake();
        StateMachine = new StateMachine<EnemyStateEnum>();
    }

    protected virtual void Start()
    {
        StateMachine.InitInitialize(EnemyStateEnum.Idle, this);
        StartCoroutine(Delaytime());
    }

    private void Update()
    {
        Debug.Log(StateMachine.CurrentState);        
        StateMachine.CurrentState.UpdateState();
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }

    protected IEnumerator Delaytime()
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
