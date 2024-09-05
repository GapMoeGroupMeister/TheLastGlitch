using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStat : MonoBehaviour
{
    private PassiveManager _passiveManager;

    private AgentMovement _agentMovement;
    private Health _health;
    private PlayerWeaponParent[] _weaponParent;



    [SerializeField] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _atkPower;
    [SerializeField] private float _critDamage;
    [SerializeField] private float _critProbability;

    private void Awake()
    {
        _agentMovement = GetComponent<AgentMovement>();
        _health = GetComponent<Health>();
        _weaponParent = GetComponentsInChildren<PlayerWeaponParent>();
        _passiveManager = GetComponentInChildren<PassiveManager>();
    }

    void Start()
    {
        _passiveManager.NotifyUsePassiveList.OnValueChanged += SetStat;

    }

    private void SetStat(List<PassiveSO> prev, List<PassiveSO> next)
    {
        foreach (PassiveSO item in _passiveManager.NotifyUsePassiveList.Value)
        {
            _maxHealth += item.addPlayerHealth;
            _moveSpeed += item.addPlayerMoveSpeed;
            _atkPower += item.addPlayerAtkPower;
            _critDamage += item.addPlayerCritDamage;
            _critProbability += item.addPlayerCritProbability;
        }


        _agentMovement.moveSpeed = _moveSpeed;
        _health.maxHealth = _maxHealth;

        foreach (PlayerWeaponParent item in _weaponParent)
        {
            item.damage += _atkPower;
            item.criticalHit += _critDamage;
            item.criticalhHitProbability += _critProbability;
        }
    }

    
}
