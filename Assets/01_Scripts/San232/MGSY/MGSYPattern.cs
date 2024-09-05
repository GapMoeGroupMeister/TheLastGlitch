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

    [Header("DickEy")]
    [SerializeField] protected string _dicKey = null;

    protected MGSY mgsy;

    public virtual void Awake()
    {   
        mgsy = GetComponent<MGSY>();
        
    }

    protected void SetDicKey(MGSYPattern pattern)
    {
        Type patternType = pattern.GetType();
        _dicKey = patternType.Name;
    }
}
