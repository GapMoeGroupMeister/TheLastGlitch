using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemySetting : Agent
{
    public UnityEvent FinalDeadEvent;

    [Header("Attack setting")]
    [SerializeField]
    public int detectRadius;
    public int attackRadius,knockbackPower,attackCooldown;
    public int damage;
    public LayerMask _whatIsPlayer;
    public ContactFilter2D contactFilter;

    public DamageCaster DamageCasterComp { get; protected set; }

    [HideInInspector] public Transform targetTrm = null;
    [HideInInspector] public float lastAttackTime;

    public bool CanStateChangeble { get; protected set; } = true;

    protected int _enemyLayers;

    public DamageCaster DamageCasterCompo { get; protected set; }

    protected Collider2D[] _colliders;

    protected override void Awake()
    {
        base.Awake();
        DamageCasterCompo = transform.Find("DamgeCaster").GetComponent<DamageCaster>();
        _enemyLayers = LayerMask.NameToLayer("Enemy");
        _colliders = new Collider2D[20];
    }
    private void Update()
    {
        Debug.Log(GetPlayerRange());
    }

    public Collider2D GetPlayerRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, detectRadius,contactFilter,_colliders);
        return count > 0 ? _colliders[0] : null;
    }

    public virtual void Attack()
    {
        DamageCasterCompo.CastDamge(damage, knockbackPower);                                                                                                                                                                                                                          
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.white;
    }

    public abstract void AnimationEndTrigger();

    public void SetDead(bool value)
    {
        IsDie = value;
        CanStateChangeble = !value;
    }
}
