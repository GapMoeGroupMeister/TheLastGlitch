using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;
    Agent _onwer;

    private void Update()
    {
        Debug.Log(_currentHealth);
    }

    public void Initialize(Agent agent)
    {
        _onwer = agent;
        ResetHealth();
    }
    private void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float amuont)
    {
        _currentHealth -= amuont;
        if(_currentHealth <=0)
        {
            gameObject.SetActive(false);
        }
    }
}
