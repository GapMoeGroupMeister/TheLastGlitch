using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemySetting : Agent
{
    public UnityEvent FinalDeadEvent;

    [Header("Attack setting")]
    public int detectRadius;
    public int attackRadius,knockbackPower,attackCooldown;
    public float stopRay;
    public int damage;
    public LayerMask _whatIsPlayer;
    public ContactFilter2D contactFilter;

    public float minX, maxX;

    int count;
    bool isPlayer;

    public EnemyStats _enemyStats;

    public DamageCaster DamageCasterComp { get; protected set; }

    public Transform targetTrm = null;
    [HideInInspector] public float lastAttackTime;

    public bool CanStateChangeble { get; protected set; } = true;

    protected int _enemyLayers;

    public DamageCaster DamageCasterCompo { get; protected set; }

    [field: SerializeField]protected Collider2D[] _colliders;

    protected override void Awake()
    {
        base.Awake();
        DamageCasterCompo = transform.Find("DamgeCaster").GetComponent<DamageCaster>();
        _enemyLayers = LayerMask.NameToLayer("Enemy");
        _colliders = new Collider2D[20];
    }

    private void Start()
    {
        detectRadius = _enemyStats.EnemydetectRadius;
        attackRadius = _enemyStats.EnemyattackRadius;
        knockbackPower = _enemyStats.EnemyknockbackPower;
        attackCooldown = _enemyStats.EnemyattackCooldown;
        stopRay = _enemyStats.EnemystopRay;
        damage = _enemyStats.Enemydamge;
    }


    public Collider2D GetPlayerRange()
    {
        count = Physics2D.OverlapCircleNonAlloc(transform.position, detectRadius,_colliders,_whatIsPlayer);

        return count > 0 ? _colliders[0] : null;
    }

    public bool GetPlayer()
    {
        isPlayer = Physics2D.Raycast(transform.position,Vector2.right,stopRay,_whatIsPlayer);
        return isPlayer;
    }

    public Vector3 GetRandomVector()
    {
        float x = Random.Range(minX,maxX);
        Vector3 vec = new Vector3(x, transform.position.y);
        return vec;
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

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.right);
    }

    public abstract void AnimationEndTrigger();

    public void SetDead(bool value)
    {
        IsDie = value;
        CanStateChangeble = !value;
    }
}
