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



}
