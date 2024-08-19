using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PassiveActivatedType
/// 패시브 발동타입
/// </summary>
public enum PATEnum
{
    Time,
    Attack,
    Hit
}

public enum PassiveType
{
    Power,
    Speed
}

public abstract class PassiveSO : ScriptableObject
{
    [Header("PlayerStat")]
    public int addPlayerHealth;
    public int addPlayerAtkPower;
    public int addPlayerMoveSpeed;
    public int addPlayerCritProbability;
    public int addPlayerCritDamage;

    [Header("PassiveStat")]
    public int damage;
    public float knockbackPower;
    public float time;
    public Vector2 distance;

    public PATEnum type;
    public PassiveType passiveType;

    public LayerMask enemyLayer;
    public abstract void Skill(Agent owner);

}
