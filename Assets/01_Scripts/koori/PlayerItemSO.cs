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
    gear
}

[CreateAssetMenu(menuName = "SO/Player/Item")]
public class PlayerItemSO : ScriptableObject
{
    public static PlayerItemSO Instance = new PlayerItemSO();

    public Dictionary<RequireItemType, int> requireItemDic = new Dictionary<RequireItemType, int>()
    {
        {RequireItemType.battery, 10},
        {RequireItemType.metal, 20 },
        {RequireItemType.pcb, 30},
        {RequireItemType.sensor, 40},
        {RequireItemType.gear, 50},
    };
    public Dictionary<GadgetType, int> havingGadgetDic = new Dictionary<GadgetType, int>()
    {
        { GadgetType.gatlingDrone, 0 },
        {GadgetType.selfDestructDrone, 0 },
        {GadgetType.hackPulse, 0},
        { GadgetType.aed, 0},
        {GadgetType.portalGun, 0},
        {GadgetType.rocketLauncher, 0},
        {GadgetType.doping, 0},
        {GadgetType.shield, 0},
    };
}
