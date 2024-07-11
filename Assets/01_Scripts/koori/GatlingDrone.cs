using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingDrone : Drone, Ipoolable
{
    [SerializeField] private float radius;

    public string ItemName => "GatlingDrone";

    public GameObject ObjectPrefab => gameObject;

    private void Start()
    {
        speed = 2.85f;
        detectRadius = radius;
    }
    protected override void Attack()
    {
    }

    public void Update() 
    {
        PushGameObject();
    }

    private void PushGameObject()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PoolManager.Instance.Push(this);
        }
    }

    public void ResetItem()
    {
        
    }
}
