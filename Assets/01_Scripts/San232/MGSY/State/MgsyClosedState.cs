using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MgsyClosedState : MGSYState<BossStateEnum>
{
    

    public MgsyClosedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();


        mgsy.StartCoroutine(MgsyClosedPatternRoutine());
    }

    public override void UpdateState()
    {
        base.UpdateState();

        
    }

    public override void Exit()
    {
        base.Exit();

        mgsy.StopCoroutine(MgsyClosedPatternRoutine());
    }

    private IEnumerator MgsyClosedPatternRoutine()
    {
        while (true)
        {
            patternIndex = Random.Range(0, mgsy.ClosedPatterns.Count);
            mgsy.ClosedPatterns[patternIndex]?.Invoke();
            yield return new WaitForSeconds(Random.Range(minCool, maxCool));
        }
    }

}
