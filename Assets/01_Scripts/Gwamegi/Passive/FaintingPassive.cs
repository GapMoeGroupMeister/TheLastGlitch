using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Passive/FaintingSO")]
public class FaintingPassive : PassiveSO
{
    public ParticleSystem enemyEffect;
    public override void Skill(Agent owner)
    {
        base.Skill(owner);
        Collider2D[] enemy = Physics2D.OverlapCircleAll(owner.transform.position, distance.x, enemyLayer);

        if (enemy.Length <= 0) return;

        

        foreach (Collider2D item in enemy)
        {
            Enemy enemyCompo = item.gameObject.GetComponent<Enemy>();

            Instantiate(enemyEffect, enemyCompo.gameObject.transform.position, Quaternion.identity);

            enemyCompo.MovementComponent._canMove =false;
            enemyCompo.fainting = true;
            enemyCompo.MovementComponent.StopImmediately();
            Debug.Log(enemyCompo.MovementComponent._canMove + "밍");
            Debug.Log(enemyCompo.fainting + "밍");

            enemyCompo.CanAttack =false;
            owner.StartCoroutine(AttackCoolTIme(enemyCompo));
        }

        
    }

    public IEnumerator AttackCoolTIme(Enemy enemyCompo)
    {
        yield return new WaitForSeconds(time);
        enemyCompo.CanAttack = true;
        enemyCompo.fainting = false;

        enemyCompo.MovementComponent._canMove = true;
        Debug.Log(enemyCompo.MovementComponent._canMove + "밍");
        Debug.Log(enemyCompo.fainting + "밍");

    }
}
