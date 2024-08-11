using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private PlayerStatSO _playerSO;

    private AgentMovement _agentMovement;
    private Health _health;

    private float _maxHealth;
    private float _moveSpeed;
    private float _atkPower;
    private float _critDamage;
    private float _critProbability;

    private void Awake()
    {
        _agentMovement = GetComponent<AgentMovement>();
        _health = GetComponent<Health>();
    }

    void Start()
    {
        _maxHealth = _playerSO.playerHealth;
        _moveSpeed = _playerSO.playerMoveSpeed;
        _atkPower = _playerSO.playerAtkPower;
        _critDamage = _playerSO.playerCritDamage;
        _critProbability = _playerSO.playerCritProbability;

        _agentMovement.moveSpeed = _moveSpeed;
        _health._maxHealth = _maxHealth;

    }

    void Update()
    {
        
    }
}
