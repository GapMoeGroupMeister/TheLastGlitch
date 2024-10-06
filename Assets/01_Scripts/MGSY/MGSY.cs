using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public enum BossStateEnum
{
    Idle,
    Closed,
    Opened,
    AngryOpened,
    Dead,
    Opening,
    Closing,
    Shooting
}

public enum PatternTypeEnum
{
    EnemySpawn,
    CoreBomb,
    LaserShoot,
    None
}

public class MGSY : EnemySetting
{
    public Coroutine patternRoutine;

    public Action OnShootLaser;

    public string state = null;
    public StateMachine<BossStateEnum> StateMachine { get; private set; }

    public Animator mgsyAnimator = null;

    public int? isRunningHash = null;

    public Dictionary<Enum, MGSYPattern> patternDic = new Dictionary<Enum, MGSYPattern>();

        

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine<BossStateEnum>();

        StateMachine.AddState(BossStateEnum.Idle, new MgsyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(BossStateEnum.Closed, new MgsyClosedState(this, StateMachine, "Closed"));
        StateMachine.AddState(BossStateEnum.Opened, new MgsyOpenedState(this, StateMachine, "Opened"));
        StateMachine.AddState(BossStateEnum.AngryOpened, new MgsyAngryOpenedState(this, StateMachine, "AngryOpened"));
        StateMachine.AddState(BossStateEnum.Dead, new MgsyDeadState(this, StateMachine, "Dead"));
        StateMachine.AddState(BossStateEnum.Opening, new MGSYOpeningState(this, StateMachine, "Opening"));
        StateMachine.AddState(BossStateEnum.Closing, new MGSYClosingState(this, StateMachine, "Closing"));
        StateMachine.AddState(BossStateEnum.Shooting, new MGSYShootingState(this, StateMachine, "Shooting"));
        StateMachine.InitInitialize(BossStateEnum.Idle, this);

    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        Debug.Log(StateMachine.CurrentState);
    }

    public override void SetDeadState()
    {
        StateMachine.ChangeState(BossStateEnum.Dead);
    }

    public void Opening2Opened()
    {
        if (HealthComponent.GetCurrentHP() > HealthComponent.maxHealth)
        {
            StateMachine.ChangeState(BossStateEnum.Opened);
        }
        else
        {
            StateMachine.ChangeState(BossStateEnum.AngryOpened);
        }
    }

    public void Coroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public Collider2D GetPlayerInRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, detectRadius, contactFilter, _colliders);
        Debug.Log(count);
        targetTrm = count > 0 ? _colliders[0].gameObject.transform : null;
        return count > 0 ? _colliders[0] : null;
    }

    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }

    public void StartPatterns(PatternTypeEnum[] patterns, float delay)
    {
        patternRoutine = StartCoroutine(PatternsRoutine(patterns, delay));
    }

    public void StopPatterns()
    {
        StopAllCoroutines();
    }

    private IEnumerator PatternsRoutine(PatternTypeEnum[] patterns, float delay)
    {
        while (true)
        {
            foreach (var pattern in patterns)
            {
                int randIndex = Random.Range(0, 100);

                if (randIndex >= 50)
                {
                    // 패턴을 딕셔너리에서 가져오기
                    if (patternDic.TryGetValue(pattern, out MGSYPattern patternInstance))
                    {
                        // 패턴 인스턴스가 null이 아닌 경우 실행
                        if (patternInstance != null)
                        {
                            patternInstance.PatternStart();
                        }
                        else
                        {
                            Debug.LogError($"{pattern}에 해당하는 패턴 인스턴스가 null입니다.");
                        }
                    }
                    else
                    {
                        Debug.LogError($"{pattern}에 해당하는 패턴이 patternDic에 존재하지 않습니다.");
                    }

                    yield return new WaitForSeconds(delay);
                }
            }
        }
    }


}

