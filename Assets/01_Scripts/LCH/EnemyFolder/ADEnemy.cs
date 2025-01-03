using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADEnemy : StateManager
{
    [SerializeField] private ShortLaserShooter _laserShooter;
    [SerializeField] private Transform _firePos;
    protected override void Awake()
    {
        base.Awake();
        _laserShooter = GetComponent<ShortLaserShooter>();
    }

    public virtual void LaserAttack()
    {
        _laserShooter.FireLaser(_firePos, targetTrm);
        DamageCasterCompo.CastDamge(damage, knockbackPower);
    }
}
