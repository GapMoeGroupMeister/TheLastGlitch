using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player2ActiveSkill : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _atkStat;
    [SerializeField] private float _speedStat;
    [SerializeField] private float _critDmgStat;

    private Health _playerHealth;
    private PlayerStat _playerStat;

    Stat _upStat = new Stat();
    Stat _downStat = new Stat();

    private float _currentHealth = 0;
    private float _activeHp;

    private bool _activeCool;

    private void Awake()
    {
        _playerStat = GetComponent<PlayerStat>();
        _playerHealth = GetComponent<Health>();

        _inputReader.OnActiveSkillEvent += UseActive;
    }

    private void OnDisable()
    {
        _inputReader.OnActiveSkillEvent -= UseActive;
    }

    private void UseActive()
    {
        GetDamage();
        PowerUp();

        StartCoroutine(returnStat());
    }

    private void GetDamage()
    {
        if (!_activeCool)
        {
            _currentHealth = _playerHealth.CurrentHealth / 2;
            if (_currentHealth <= 0)
            {
                _playerHealth.CurrentHealth = 10;
            }
            _playerHealth.TakeDamage(_currentHealth, Vector2.zero, 0);
            _activeHp = _currentHealth;
        }
    }

    private void PowerUp()
    {
        _upStat.atkPower += _atkStat;
        _upStat.moveSpeed += _speedStat;
        _upStat.critDamage += _critDmgStat;
        _playerStat.StatSet(_upStat);
    }

    private IEnumerator returnStat()
    {
        _activeCool = true;
        yield return new WaitForSeconds(15f);
        _playerHealth.AddCurrentHP((int)_activeHp);
        _downStat.atkPower -= _atkStat;
        _downStat.moveSpeed -= _speedStat;
        _downStat.critDamage -= _critDmgStat;
        _playerStat.StatSet(_downStat);
    }
}
