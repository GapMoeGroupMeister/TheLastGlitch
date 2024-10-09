using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreHandler : MGSYPattern
{
    [SerializeField] private List<Core> cores = new List<Core>();
    public UnityEvent explosionEffect;
    private int maxCoreCount = 2;
    private bool _isThereCore = true;

    protected override void Awake()
    {
        base.Awake();
        Init(PatternTypeEnum.Core);
        
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
        if(_isThereCore)
        {
            explosionEffect?.Invoke();
            foreach (Core core in cores)
            {
                core.DestroyCore();
            }

            _isThereCore = false;
        }
        else
        {
            CoreRepair();
        }
        
    }

    private void CoreRepair()
    {
        Core.Instance.CoreCount = maxCoreCount;
        foreach(Core core in cores)
        {
            core.gameObject.SetActive(true);
            core.CoreHealthCompo.AddCurrentHP((int)core.CoreHealthCompo.maxHealth);
            mgsy.StateMachine.ChangeState(BossStateEnum.Closed);
        }

        _isThereCore = true;
    }

    private void CoreCheck()
    {
        if(Core.Instance.CoreCount == 0)
        {
            mgsy.StateMachine.ChangeState(BossStateEnum.Opening);
        }
    }
}
