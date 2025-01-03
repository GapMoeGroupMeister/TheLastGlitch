using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public PlayerTypeEnum PlayerType;
    public PlayerInfoSO PlayerInfo;
    public GadgetType SelectedGadget = GadgetType.None;

    public int money;
    private void Awake()
    {
        var obj = FindObjectsOfType<DataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
