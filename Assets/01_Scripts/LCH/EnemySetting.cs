using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySetting : Agent
{
    [Header("Attack setting")]
    [SerializeField]
    public int detectRadius;
    public int attackRadius,knockbackPower,attackCooldown;
    public int damage;
    public LayerMask whatisPlayer;
    public ContactFilter2D contactFilter;

    public bool CanStateChangeble { get; protected set; } = true;

    private Collider2D[] _colliders;

    public Collider2D GetPlayerRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, detectRadius, contactFilter, _colliders);
        Debug.Log("°¨ÁöµÊ");
        return count > 0 ? _colliders[0] : null;
    }

    public virtual void Attack()
    {

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.white;
    }

    public void AnimationEndTrigger()
    {

    }

    public void SetDead(bool value)
    {
        IsDie = value;
        CanStateChangeble = !value;
    }
}
