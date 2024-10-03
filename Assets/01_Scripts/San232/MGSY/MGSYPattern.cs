using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGSYPattern : MonoBehaviour
{
    [Header("CoolTime")]
    [SerializeField] protected float _spawnCoolTime = 0;
    [SerializeField] protected float _minCoolTime = 2;
    [SerializeField] protected float _maxCoolTime = 4;
    [SerializeField] protected float _patternCoolTime = 0;
    [SerializeField] protected float _maxPatternCool = 6;
    [SerializeField] protected float _minPatternCool = 12;


    protected MGSY mgsy;

    protected virtual void Awake()
    {
        mgsy = GetComponent<MGSY>();
    }

    protected void Init(PatternTypeEnum patternName)
    {
        mgsy.patternDic.Add(patternName, this);
    }

    public virtual void PatternStart()
    {
        
    }

    public virtual void PatternEnd()
    {
        
    }
}
