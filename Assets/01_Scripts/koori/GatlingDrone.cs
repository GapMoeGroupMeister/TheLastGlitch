using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingDrone : Drone
{
    [SerializeField] private float radius;
    private void Start()
    {
        speed = 2.85f;
        detectRadius = radius;
    }
    protected override void Attack()
    {
    }
}
