using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSY : EnemySetting
{
    [SerializeField] private GameObject testEnemyPrefab;
    [SerializeField] protected Health health;
    public string state;
    public StateMachine<BossStateEnum> StateMachine { get; private set; }
    [field : SerializeField] public GameObject Shell1 { get; set; }
    [field : SerializeField] public GameObject Sheel2 { get; set; }
    public GameObject test => testEnemyPrefab;

    protected override void Awake()
    {
        base.Awake();

        health = GetComponent<Health>();

        StateMachine = new StateMachine<BossStateEnum>();

        StateMachine.AddState(BossStateEnum.Idle, new MgsyIdleState(this, StateMachine, "Idle"));
        StateMachine.AddState(BossStateEnum.Closed, new MgsyClosedState(this, StateMachine, "Closed"));
        StateMachine.AddState(BossStateEnum.Opened, new MgsyOpenedState(this, StateMachine, "Opened"));
        StateMachine.AddState(BossStateEnum.AngryOpened, new MgsyAngryOpenedState(this, StateMachine, "AngryOpened"));

        StateMachine.InitInitialize(BossStateEnum.Idle, this);
    }
    
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        
    }

    public override void SetDeadState()
    {
        
    }

    public Collider2D GetPlayerInRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, detectRadius, contactFilter, _colliders);
        Debug.Log(count);
        return count > 0 ? _colliders[0] : null;
    }

    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }

    public void SpawnEntity(GameObject entities)
    {
        Instantiate(entities);
    }
}
