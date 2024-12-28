using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player2ActiveSkill : MonoBehaviour
{
    public static Player2ActiveSkill Instance;

    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _atkStat;
    [SerializeField] private float _speedStat;
    [SerializeField] private float _critDmgStat;

    private Health _playerHealth;
    private PlayerStat _playerStat;
    private AgentMovement _agent;

    Stat _upStat = new Stat();
    Stat _downStat = new Stat();

    private float _currentHealth = 0;
    private float _activeHp;

    private bool _activeCool;

    private bool _isbool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        

        _playerStat = GetComponent<PlayerStat>();
        _playerHealth = GetComponent<Health>();

    }

    private void Start()
    {
        _inputReader.OnActiveSkillEvent += UseActive;
    }

    private void UseActive()
    {
        GetDamage();
    }

    private void GetDamage()
    {
        if (!_activeCool)
        {
            _currentHealth = _playerHealth.CurrentHealth / 2;
            _activeHp = _currentHealth;
            _playerHealth.TakeDamage(_currentHealth, Vector2.zero, 0);
            PowerUp();

            StartCoroutine(returnStat());
        }
    }

    private void PowerUp()
    {
        Debug.Log("UpStat");
        _upStat.atkPower += _atkStat;
        _upStat.moveSpeed += _speedStat;
        _upStat.critDamage += _critDmgStat;
        _playerStat.StatSet(_upStat);
    }

    public void ErrorActive()
    {
        if (_isbool)
        {
            _playerStat.StatSet(_downStat);
            ReturnPower();
            _activeCool = false;
            _isbool = false;
        }
    }

    private void ReturnPower()
    {
        Debug.Log("DownStat");

        
        

        Stat downStat = new Stat();
        downStat.atkPower -= _atkStat;
        downStat.moveSpeed -= _speedStat;
        downStat.critDamage -= _critDmgStat;

        _upStat.atkPower -= _atkStat;
        _upStat.moveSpeed -= _speedStat;
        _upStat.critDamage -= _critDmgStat;

        _playerStat.StatSet(downStat);


    }

    private IEnumerator returnStat()
    {
        _activeCool = true;
        _isbool = true;
        yield return new WaitForSeconds(8f);
        _playerHealth.CurrentHealth += ((int)_activeHp);
        ReturnPower();
        _isbool = false;
        yield return new WaitForSeconds(10f);
        _activeCool = false;
    }
}
