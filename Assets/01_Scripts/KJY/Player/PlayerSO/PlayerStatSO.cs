using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "SO/Player1/Stat")]
public class PlayerStatSO : ScriptableObject
{
    public int playerHealth;
    public int playerAtkPower;
    public int playerMoveSpeed;
    public int playerCritProbability;
    public int playerCritDamage;

    public string type = "1";
}
