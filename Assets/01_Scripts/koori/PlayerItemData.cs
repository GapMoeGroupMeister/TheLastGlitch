using EasySave.Json;
using System.Collections.Generic;
using UnityEngine;

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

    public GadgetType CurrentGadget { get; set; } = GadgetType.None;

    private void Awake()
    {
        gadgetData = new ItemData();

        LoadItemData();
    }

    [ContextMenu("To Json Data")]
    public void SaveGadgetDataToJson()
    {
        OverwritingData(false);

        EasyToJson.ToJson(gadgetData, "ItemData", true);

        LoadItemData();
    }
    /// <summary>
    /// ���� ������ �������� �ʾƼ� playerData�� null�̸�, �⺻������ �ʱ�ȭ�ϰ� ������.
    /// </summary>
    private void LoadItemData()
    {
        gadgetData = EasyToJson.FromJson<ItemData>("ItemData");

        if (gadgetData == null)
        {
            gadgetData = new ItemData();
            SaveGadgetDataToJson();
            Debug.Log("���ο� ���̺� ������ �����߽��ϴ�.");
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
    }
}