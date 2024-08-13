using System.Collections;
using UnityEngine;

public enum EnemyStateEnum
{
    Idle,
    Attack,
    Chase,
    Walk,
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
    public bool isMelee = true;
    public bool isCloser;
    public bool isBoom;
    public Vector2 dir;
    public StateMachine<EnemyStateEnum> StateMachine { get; private set; }


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
        if(targetTrm != null && IsDie == false)
        {
            HandleSpriteFlip(targetTrm.position);
        }

        if(MovementComponent._xMove < 0 && MovementComponent._xMove != 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(MovementComponent._xMove > 0 && MovementComponent._xMove !=0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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
