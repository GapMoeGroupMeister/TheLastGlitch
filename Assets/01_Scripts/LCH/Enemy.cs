using System.Collections;
using UnityEngine;

public enum EnemyStateEnum
{
    Idle,
    Attack,
    Chase,
    Walk,
    Hit,
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
    public bool CanAttack = true;
    public bool FirstAttack = true;
    public bool Boom = false;
    public float distance;
    public StateMachine<EnemyStateEnum> StateMachine { get; private set; }


    public override void SetDeadState()
    {
        StateMachine.ChangeState(EnemyStateEnum.Dead);
    }

    public void GetHit()
    {
        StateMachine.ChangeState(EnemyStateEnum.Hit);
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
            //HandleSpriteFlip(targetTrm.position);
        }

        if(MovementComponent._xMove < 0 && MovementComponent._xMove != 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(MovementComponent._xMove > 0 && MovementComponent._xMove !=0)
        {
            transform.localScale = Vector3.one;
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
