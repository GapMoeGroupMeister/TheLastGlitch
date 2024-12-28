using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Passive/RecoveryPassive")]
public class RecoveryPassive : PassiveSO
{
    [Range(0,10)] public float healCount;

    public override void Skill(Agent owner)
    {
        base.Skill(owner);
        Health playerHealth = owner.GetComponent<Health>();
        playerHealth.AddCurrentHP((int)healCount);
    }
}
