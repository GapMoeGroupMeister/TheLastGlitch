using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;

    public float CurrentHealth;
    Agent _onwer;

    public bool IsHittable { get; set; } = true;


    public UnityEvent OnGetHit;
    public UnityEvent<int> OnGetDamageEvent;
    public UnityEvent OnDeadEvent;
    public Pooling pool;
    private void Awake()
    {
        pool = GetComponent<Pooling>();
        pool.OnReset += ResetHealth;
    }

    private void OnDestroy()
    {
        pool.OnReset -= ResetHealth;
    }

    public void Initialize(Agent agent)
    {
        _onwer = agent;
        ResetHealth();
    }
    private void ResetHealth()
    {
        StartCoroutine(ResetHealthCoroutine());
    }

    private IEnumerator ResetHealthCoroutine()
    {
        while (CurrentHealth <= 0)
        {
            CurrentHealth = maxHealth;
            yield return null;
        }
    }

    public void AddCurrentHP(int addHealth)
    {
        if (addHealth + CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
        else
        {
            CurrentHealth += addHealth;
        }



    }

    public float GetCurrentHP()
    {
        return CurrentHealth;
    }


    public void TakeDamage(float amount, Vector2 dir, float knockbackPower)
    {
        if (IsHittable)
        {
            CurrentHealth -= amount;
            OnGetHit?.Invoke();
            if (knockbackPower > 0)
                _onwer.MovementComponent.GetKnockback(dir, knockbackPower);
            OnGetDamageEvent?.Invoke((int)amount);
            Debug.Log(CurrentHealth + " " + gameObject.name);
            if (CurrentHealth <= 0)
            {
                OnDeadEvent?.Invoke();
                //ResetHealth();
            }

        }
    }
}
