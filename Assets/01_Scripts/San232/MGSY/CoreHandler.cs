using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHandler : MGSYPattern
{
    [SerializeField] private List<Core> cores = new List<Core>();

    private void Awake()
    {
        Init(PatternTypeEnum.CoreBomb, this);
        
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

    private void CoreCheck()
    {
        Debug.Log("Check");
        if(Core.coreCount == 0)
        {
            mgsy.StateMachine.ChangeState(BossStateEnum.Opening);
        }
    }
}
