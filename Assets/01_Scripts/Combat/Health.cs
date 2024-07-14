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

    public UnityEvent OnGetHit { get ; set; }

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

    public void TakeDamage(float amount, Vector2 normal, Vector2 point, float knockbackPower)
    {
        _currentHealth -= amount;
        if(_currentHealth <=0)
        {
            gameObject.SetActive(false);
        }

        if (knockbackPower > 0)
            _onwer.MovementComponent.GetKnockback(normal * -1, knockbackPower);
    }
}
