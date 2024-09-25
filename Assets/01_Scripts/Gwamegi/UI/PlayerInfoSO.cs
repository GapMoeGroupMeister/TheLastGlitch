using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerInfoSO")]
public class PlayerInfoSO : ScriptableObject
{
    public Sprite playerSpreite;
    public string playerName;
    public string playerPassiveDesc;
    public string playerActiveSkillDesc;
    public PlayerTypeEnum playerType;
    [Header("PlayerStatInfo")]
    public float maxHealth;
    public float moveSpeed;
    public float atkPower;
    public float critDamage;
    public float critProbability;

}
