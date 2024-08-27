using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MgsyClosedState : MGSYState<BossStateEnum>
{
    public Action OnClosedEnter;

    private int patternIndex;
    private float minCool= 3f;
    private float maxCool = 7f;

    public MgsyClosedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();


        
    }

    public override void UpdateState()
    {
        base.UpdateState();

        mgsy.StartCoroutine(MgsyClosedPatternRoutine());
    }

    public override void Exit()
    {
        base.Exit();
    }

    private IEnumerator MgsyClosedPatternRoutine()
    {
        patternIndex = Random.Range(0, mgsy.ClosedPatterns.Count);
        mgsy.ClosedPatterns[patternIndex]?.Invoke();
        yield return new WaitForSeconds(Random.Range(minCool, maxCool));
    }
}
