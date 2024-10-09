using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgsyIdleState : MGSYState<BossStateEnum>
{
    public MgsyIdleState(MGSY enemyBase, StateMachine<BossStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {

    }

    private void Change2Closed()
    {
        
        _stateMachine.ChangeState(BossStateEnum.Closed);
        
    }


    public override void Enter()
    {
        base.Enter();
        mgsy.HealthComponent.IsHittable = false;
        mgsy.targetTrm.position = new Vector3(-9, -1.3f, 0);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (mgsy.GetPlayerInRange() != null)
        {
            if (mgsy.GetPlayerInRange().gameObject.CompareTag("Player"))
            {
                Change2Closed();
            }
        }

        //테스트용 코드
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mgsy.StartPatterns(new PatternTypeEnum[] { PatternTypeEnum.LaserShoot }, 10);
        //}
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
