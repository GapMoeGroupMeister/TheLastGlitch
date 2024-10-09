using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Passive/LightningDash")]
public class LightningDash : PassiveSO
{
    private Enemy targetEnemy;
    private Transform targetTrm;

    [SerializeField] private float _moveSpeed;

    public override void Skill(Agent owner)
    {
        base.Skill(owner);
        Collider2D[] enemyArray = Physics2D.OverlapCircleAll(owner.transform.position, radius, enemyLayer);

        if (enemyArray.Length <= 0) return;

        foreach (Collider2D item in enemyArray)
        {
            if (item != null)
            {
                Enemy enemy = item.GetComponent<Enemy>();

                if (targetEnemy == null)
                {
                    targetTrm = enemy.transform;
                    targetEnemy = enemy;

                }
                else if (Vector3.Distance(targetEnemy.transform.position, owner.transform.position) > Vector3.Distance(owner.transform.position, enemy.transform.position))
                {
                    targetEnemy = enemy;
                    targetTrm = enemy.transform;
                }
            }
            
        }

        if (targetEnemy.transform.position.x > owner.transform.position.x)
        {
            targetTrm.position += Vector3.right * 3;
        }
        else
        {
            targetTrm.position += Vector3.left * 3;

        }

        Vector3 dir = targetEnemy.transform.position - owner.transform.position;
        owner.transform.DOMove(targetEnemy.transform.position, time);
        targetEnemy.GetComponent<Health>().TakeDamage(damage, dir, 0);


    }
}
