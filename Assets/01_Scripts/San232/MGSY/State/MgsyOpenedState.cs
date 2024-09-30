using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyOpenedState : MGSYState<BossStateEnum>
{
    private PatternTypeEnum[] _openedPatterns = { PatternTypeEnum.EnemySpawn, PatternTypeEnum.LaserShoot };
    public MgsyOpenedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
         
    }

    public override void Enter()
    {
        base.Enter();
        mgsy.HealthComponent.IsHittable = true;
        mgsy.StartPatterns(_openedPatterns, 15f);
    }

    
}
