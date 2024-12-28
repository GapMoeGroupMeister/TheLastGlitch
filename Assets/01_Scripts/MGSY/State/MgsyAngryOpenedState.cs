using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyAngryOpenedState : MGSYState<BossStateEnum>
{

    private PatternTypeEnum[] _angryOpenedPatterns = { PatternTypeEnum.EnemySpawn , PatternTypeEnum.LaserShoot , PatternTypeEnum.Core};
    public MgsyAngryOpenedState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        mgsy.HealthComponent.IsHittable = true;
        mgsy.StartPatterns(_angryOpenedPatterns, 12f);
    }

}
