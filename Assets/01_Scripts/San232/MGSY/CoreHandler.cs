using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHandler : MGSYPattern
{
    [SerializeField] private List<Core> cores = new List<Core>();

    protected override void Awake()
    {
        base.Awake();
        Init(PatternTypeEnum.CoreBomb);
        
    }

    private void OnEnable()
    {
        cores[0].OnDestroyCore += CoreCheck;
        cores[1].OnDestroyCore += CoreCheck;
    }

    private void OnDisable()
    {
        cores[0].OnDestroyCore -= CoreCheck;
        cores[1].OnDestroyCore -= CoreCheck;
    }

    public override void PatternStart()
    {
        
        foreach (Core core in cores)
        {
            core.DestroyCore();
        }
    }

    public void CoreRepair()
    {
        foreach(Core core in cores)
        {
            core.gameObject.SetActive(true);
            core.CoreHealthCompo.TakeDamage(core.CoreHealthCompo.maxHealth * -1, Vector2.zero, 0f);
            mgsy.StateMachine.ChangeState(BossStateEnum.Closed);
        }
    }

    private void CoreCheck()
    {
        if(Core.coreCount == 0)
        {
            mgsy.StateMachine.ChangeState(BossStateEnum.Opening);
        }
    }
}
