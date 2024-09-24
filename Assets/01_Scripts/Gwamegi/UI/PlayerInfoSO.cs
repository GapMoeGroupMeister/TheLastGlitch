using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerInfoSO")]
public class PlayerInfoSO : ScriptableObject
{
    public Sprite playerSpreite;
    public string playerName;
    public string playerStatInfo;
    public string playerPassiveDesc;
    public PlayerTypeEnum playerType;

}
