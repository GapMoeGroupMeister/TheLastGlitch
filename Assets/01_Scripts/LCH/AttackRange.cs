using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackRange : Agent
{
    [Header("Attack setting")]
    [SerializeField]
    public int detectRadius;
    public int attackRadius,knockbackPower,attackCooldown;
    public int damage;
    public LayerMask whatisPlayer;
    public ContactFilter2D contactFilter;

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.white;
    }

    public abstract void AnimationEndTrigger();
}
