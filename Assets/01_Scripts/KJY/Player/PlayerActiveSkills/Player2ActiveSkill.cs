using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ActiveSkill : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private Health _playerHealth;

    private float _currentHealth;
    private float _activeHp;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();

        _inputReader.OnActiveSkillEvent += UseActive;
    }

    private void UseActive()
    {
        Debug.Log("UseSkill");
        _currentHealth = _playerHealth.GetCurrentHP();
        Debug.Log(_currentHealth);
        _playerHealth.TakeDamage(_currentHealth / 2, Vector2.zero, 0);
        _activeHp = _currentHealth / 2;

        StartCoroutine(returnHp());
    }

    private IEnumerator returnHp()
    {
        _playerHealth.AddCurrentHP((int)_activeHp);
        yield return null;
    }
}
