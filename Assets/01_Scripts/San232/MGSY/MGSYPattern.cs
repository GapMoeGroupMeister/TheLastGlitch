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


    protected void Init(PatternTypeEnum patternName, MGSYPattern pattern)
    {
        mgsy = GetComponent<MGSY>();
        mgsy.patternDic.Add(patternName, pattern);
    }

    protected virtual void PatternStart()
    {
        
    }
    
    protected virtual void PatternEnd()
    {
        
    }
}
