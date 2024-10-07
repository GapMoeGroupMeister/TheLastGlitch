using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public PlayerTypeEnum PlayerType;
    public PlayerInfoSO PlayerInfo;
}
