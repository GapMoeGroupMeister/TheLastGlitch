using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingDrone : Drone
{
    [SerializeField] private float _radius;
    private bool _cool = false;
    [SerializeField]private float _coolTime = 1;

    private void Start()
    {
        speed = 2.9f;
        detectRadius = _radius;
    }
    protected override void Attack()
    {
            Debug.Log(".");
        if (!_cool)
        {
            StartCoroutine(shot());
        }
    }

    public override void Update() 
    {
        base.Update();
    }

    private IEnumerator shot()
    {
        _cool = true;
        PoolManager.Instance.Pop("GatlingBullet");

        yield return new WaitForSeconds(_coolTime);
         _cool = false;
    }

    public void ResetItem()
    {
        
    }
}
