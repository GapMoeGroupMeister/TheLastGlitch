using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnHitEvent;
    public UnityEvent OnDeadEvent;

    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;
    Agent _onwer;

    public void Initialize(Agent agent)
    {
        _onwer = agent;
        ResetHealth();
    }

    private void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amuont, Vector2 normal, Vector2 point, float knockbackPowr)
    {
        _currentHealth -= amuont;
        OnHitEvent?.Invoke();
        if(_currentHealth <=0)
        {
            _currentHealth = _maxHealth;
            OnDeadEvent?.Invoke();
        }
    }
}
