using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Passive/ShockWaveSO")]
public class ShockWaveSO : PassiveSO
{
    public override void Skill(Agent owner)
    {
        base.Skill(owner);
        Collider2D[] enemy = Physics2D.OverlapCircleAll(owner.transform.position, distance.x, enemyLayer);
        Debug.Log("½ºÅ³ ¹ßµ¿µÊ");
        if (enemy.Length <= 0) return;
        Debug.Log(enemy);
        foreach (Collider2D item in enemy)
        {
            item.GetComponent<Health>().TakeDamage(damage, item.transform.position.normalized, knockbackPower);
        }


    }

}
