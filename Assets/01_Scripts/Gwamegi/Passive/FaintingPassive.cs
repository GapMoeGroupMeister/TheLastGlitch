using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/FaintingSO")]
public class FaintingPassive : PassiveSO
{
    public override void Skill(Agent owner)
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(owner.transform.position, distance.x, enemyLayer);

        if (enemy.Length <= 0) return;

        

        foreach (Collider2D item in enemy)
        {
            Enemy enemyCompo = item.gameObject.GetComponent<Enemy>();


            enemyCompo.MovementComponent._canMove =false;
            enemyCompo.MovementComponent.StopImmediately();
            enemyCompo.StateMachine.ChangeState(EnemyStateEnum.Idle);

            enemyCompo.CanAttack =false;

        }
    }
}
