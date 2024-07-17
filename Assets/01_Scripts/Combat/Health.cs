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

    public bool IsHittable { get; set; } = true;


    public UnityEvent OnGetHit;

    private void Update()
    {
        //Debug.Log(_currentHealth);
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
        if(IsHittable)
        {
            if (knockbackPower > 0)
                _onwer.MovementComponent.GetKnockback(normal * -1, knockbackPower);
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }

        }
    }
}
