using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doping : GadgetParent
{
    [SerializeField] private  PlayerStat _stat;
    [SerializeField] private float _dopedHealth;
    [SerializeField] private float _dopedMoveSpeed;
    [SerializeField] private float _dopedAtkPower;
    [SerializeField] private float _dopedCritDamage;
    [SerializeField] private float _dopedScritProbability;
    private Stat _dopedStat;
    private void Start()
    {
        _dopedStat = new Stat();
        _dopedStat.maxHealth = _dopedHealth;
        _dopedStat.moveSpeed = _dopedMoveSpeed;
        _dopedStat.atkPower = _dopedAtkPower;
        _dopedStat.critDamage = _dopedCritDamage;
        _dopedStat.critProbability = _dopedScritProbability;
        _isUse += StatDoping;
    }

    private void StatDoping()
    {
        _stat.StatSet(_dopedStat);
        Destroy(gameObject);
    }
}
