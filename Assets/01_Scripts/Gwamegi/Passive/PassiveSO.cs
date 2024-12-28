using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

/// <summary>
/// PassiveActivatedType
/// ?¬ß?? ??????
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
    public float radius;

    [Header("Effect")]
    public bool _isUsePlayerEffect;
    public ParticleSystem effect;

    public PATEnum type;
    public PassiveType passiveType;

    public LayerMask enemyLayer;
    public virtual void Skill(Agent owner)
    {
        if (_isUsePlayerEffect)
        {
            Instantiate(effect,owner.transform);
        }
    }

    

}
