using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MgsyClosedState : MGSYState<BossStateEnum>
{
    public Action OnClosedEnter;

    private int patternIndex;
    private int minIndex = 1;
    private int maxIndex = 101;
    private float minCool= 3f;
    private float maxCool = 7f;

    public MgsyClosedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        health.IsHittable = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        MgsyClosedPatternRoutine();

        if (patternIndex >= 0 && patternIndex < 50)
        {
            Debug.Log("¾ÆÀÕ");
        }
        else if (patternIndex >= 50)
        {
            Debug.Log("ÀÀ¾î¾ÆÀÕ");
        }
    }

    private IEnumerator MgsyClosedPatternRoutine()
    {
        patternIndex = Random.Range(minIndex, maxIndex);
        yield return new WaitForSeconds(Random.Range(minCool, maxCool));
    }
}
