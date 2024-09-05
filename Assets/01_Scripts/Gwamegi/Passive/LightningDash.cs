using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDash : PassiveSO
{
    List<Enemy> enemyList = new List<Enemy>();

    public override void Skill(Agent owner)
    {
        base.Skill(owner);
        Collider2D[] enemy = Physics2D.OverlapCircleAll(owner.transform.position, radius, enemyLayer);


        if (enemy.Length <= 0) return;



        foreach (Collider2D item in enemy)
        {
            enemyList.Add(item.gameObject.GetComponent<Enemy>());
        }

    }
}
