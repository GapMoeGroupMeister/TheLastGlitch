using EasySave.Json;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public enum GadgetType
{
    None,
    hackPulse,
    aed,
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
public class PlayerItemData : MonoSingleton<PlayerItemData>
{
    public ItemData gadgetData;
    public GameObject Hack, Doping, AED, Shield, Rocket;

    public GadgetType CurrentGadget { get; set; } = GadgetType.None;

    private void Awake()
    {
        gadgetData = new ItemData();

        LoadItemData();
    }

    [ContextMenu("To Json Data")]
    public void SaveGadgetData()
    {
        OverwritingData(true);

        EasyToJson.ToJson(gadgetData, "ItemData", true);

        LoadItemData();
    }
    public void SaveGadgetDataToJson()
    {
        OverwritingData(false);

        EasyToJson.ToJson(gadgetData, "ItemData", true);

        LoadItemData();
    }
    /// <summary>
    /// 만약 파일이 존재하지 않아서 playerData가 null이면, 기본값으로 초기화하고 저장함.
    /// </summary>
    private void LoadItemData()
    {
        gadgetData = EasyToJson.FromJson<ItemData>("ItemData");

        if (gadgetData == null)
        {
            gadgetData = new ItemData();
            SaveGadgetDataToJson();
            Debug.Log("새로운 세이브 파일을 생성했습니다.");
        }

        OverwritingData(true);
    }

    private void OverwritingData(bool isLoad)
    {
        if (isLoad)
        {
            CurrentGadget = gadgetData.EquipGadget;

            requireItemDic[RequireItemType.battery] = gadgetData.Battery;
            requireItemDic[RequireItemType.metal] = gadgetData.Metal;
            requireItemDic[RequireItemType.gear] = gadgetData.Gear;
            requireItemDic[RequireItemType.pcb] = gadgetData.Pcb;
            requireItemDic[RequireItemType.sensor] = gadgetData.Sensor;

            havingGadgetDic[GadgetType.rocketLauncher] = gadgetData.RocketLauncher;
            havingGadgetDic[GadgetType.aed] = gadgetData.Aed;
            havingGadgetDic[GadgetType.doping] = gadgetData.Doping;
            havingGadgetDic[GadgetType.shield] = gadgetData.Shield;
            havingGadgetDic[GadgetType.hackPulse] = gadgetData.HackPulse;
        }
        else
        {
            gadgetData.EquipGadget = CurrentGadget;

            gadgetData.Battery = requireItemDic[RequireItemType.battery];
            gadgetData.Metal = requireItemDic[RequireItemType.metal];
            gadgetData.Gear = requireItemDic[RequireItemType.gear];
            gadgetData.Pcb = requireItemDic[RequireItemType.pcb];
            gadgetData.Sensor = requireItemDic[RequireItemType.sensor];

            gadgetData.RocketLauncher = havingGadgetDic[GadgetType.rocketLauncher];
            gadgetData.Aed = havingGadgetDic[GadgetType.aed];
            gadgetData.Doping = havingGadgetDic[GadgetType.doping];
            gadgetData.Shield = havingGadgetDic[GadgetType.shield];
            gadgetData.HackPulse = havingGadgetDic[GadgetType.hackPulse];
        }
    }

    public Dictionary<RequireItemType, int> requireItemDic = new Dictionary<RequireItemType, int>()
    {
        {RequireItemType.battery, 0},
        {RequireItemType.metal, 0 },
        {RequireItemType.pcb, 0},
        {RequireItemType.sensor, 0},
        {RequireItemType.gear, 0},
    };
    public Dictionary<GadgetType, int> havingGadgetDic = new Dictionary<GadgetType, int>()
    {
        {GadgetType.hackPulse, 0},
        { GadgetType.aed, 0},
        {GadgetType.rocketLauncher, 0},
        {GadgetType.doping, 0},
        {GadgetType.shield, 0},
    };

    [System.Serializable]
    public class ItemData
    {
        public GadgetType EquipGadget = GadgetType.None;
        public int Battery = 0;
        public int Metal = 0;
        public int Pcb = 0;
        public int Sensor = 0;
        public int Gear = 0;
        public int Shield = 0;
        public int Aed = 0;
        public int RocketLauncher = 0;
        public int Doping = 0;
        public int HackPulse = 0;
        public int Gold = 0;   
    }

    public void GadgetInit(GadgetType type)
    {
        switch (type)
        {
            case GadgetType.aed:Instantiate(AED); break;
            case GadgetType.hackPulse: Instantiate(Hack); break;
            case GadgetType.doping:Instantiate(Doping); break;
            case GadgetType.shield:Instantiate(Shield); break;
            case GadgetType.rocketLauncher: Instantiate(Rocket); break;

            default: break;
        }
    }
    public void GadgetMinus(GadgetType type)
    {
        havingGadgetDic[type]--;
        SaveGadgetDataToJson();
    }
}
