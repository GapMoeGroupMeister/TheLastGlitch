using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GadgetType
{
    gatlingDrone,
    selfDestructDrone,
    hackPulse,
    aed,
    portalGun,
    rocketLauncher,
    doping,
    shield
}
public enum RequireItemType
{
    battery,
    pcb,
    sensor,
    metal,
}

[CreateAssetMenu(menuName = "SO/Player/Item")]
public class PlayerItemSO : ScriptableObject
{
    public int gatlingDrone;
    public int selfDestructDrone;
    public int hackPulse;
    public int aed;
    public int portalGun;
    public int rocketLauncher;
    public int doping;
    public int shield;

    public Dictionary<RequireItemType, int> requireItemDic = new Dictionary<RequireItemType, int>()
    {
        {RequireItemType.battery, 0},
        {RequireItemType.metal, 0 },
        {RequireItemType.pcb, 0},
        {RequireItemType.sensor, 0},
    };
}
