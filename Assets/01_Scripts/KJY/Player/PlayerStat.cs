using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Stat
{
    public float maxHealth;
    public float moveSpeed;
    public float atkPower;
    public float critDamage;
    public float critProbability;
}

public class PlayerStat : MonoBehaviour
{
    private PassiveManager _passiveManager;

    private AgentMovement _agentMovement;
    private Health _health;
    private PlayerWeaponParent[] _weaponParent;
    


    [SerializeField] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _atkPower;
    [SerializeField] private float _critDamage;
    [SerializeField] private float _critProbability;

    private void Awake()
    {
        _agentMovement = GetComponent<AgentMovement>();
        _health = GetComponent<Health>();
        _weaponParent = GetComponentsInChildren<PlayerWeaponParent>();
        _passiveManager = GetComponentInChildren<PassiveManager>();
    }

    void Start()
    {
        _passiveManager.NotifyUsePassiveList.OnValueChanged += StatAdd;
    }

    private void StatAdd(List<PassiveSO> prev, List<PassiveSO> next)
    {
        StatSet(next);
    }

    public void StatSet<T>(T t)
    {
        if (typeof(T) == typeof(List<PassiveSO>))
        {
            foreach (PassiveSO item in t as List<PassiveSO>)
            {
                _maxHealth += item.addPlayerHealth;
                _moveSpeed += item.addPlayerMoveSpeed;
                _atkPower += item.addPlayerAtkPower;
                _critDamage += item.addPlayerCritDamage;
                _critProbability += item.addPlayerCritProbability;
            }
        }

        if (typeof(T) == typeof(Stat))
        {
            Stat stat = t as Stat;

                _maxHealth += stat.maxHealth;
                _moveSpeed += stat.moveSpeed;
                _atkPower += stat.atkPower;
                _critDamage += stat.critDamage;
                _critProbability += stat.critProbability;
        }

        _agentMovement.moveSpeed = _moveSpeed;
        _health.maxHealth = _maxHealth;

        foreach (PlayerWeaponParent item in _weaponParent)
        {
            item.damage += _atkPower;
            item.criticalHit += _critDamage;
            item.criticalhHitProbability += _critProbability;
        }
    }
}
