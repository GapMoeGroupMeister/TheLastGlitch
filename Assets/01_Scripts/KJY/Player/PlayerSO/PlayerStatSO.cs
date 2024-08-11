using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "SO/Player1/Stat")]
public class PlayerStatSO : MonoBehaviour
{
    public int _playerHealth;
    public int _playerAtkPower;
    public int _playerMoveSpeed;
    public int _playerCritProbability;
    public int _playerCritDamage;

    public AgentMovement _agentMm;
    public Health _health;
    public Player1 _player1Stat;

    private void StatAdjustment()
    {
        _playerHealth = 
    }
}
