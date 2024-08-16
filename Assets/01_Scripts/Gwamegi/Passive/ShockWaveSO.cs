using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/ShockWaveSO")]

public class ShockWaveSO : PassiveSO
{
    public override void Skill(Agent owner)
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(owner.transform.position, distance.x,enemyLayer);

        foreach (Collider2D item in enemy)
        {
            item.GetComponent<Health>().TakeDamage(damage,item.transform.position.normalized, knockbackPower);
        }
    }
}
