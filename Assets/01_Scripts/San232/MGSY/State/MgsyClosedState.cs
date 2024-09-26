using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MgsyClosedState : MGSYState<BossStateEnum>
{
    private PatternTypeEnum[] _closedPatterns = {PatternTypeEnum.EnemySpawn, PatternTypeEnum.CoreBomb};

    public MgsyClosedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        mgsy.StartPatterns(_closedPatterns, 15f);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        
    }

    public override void Exit()
    {
        base.Exit();
        mgsy.StopPatterns();
    }

    

}
