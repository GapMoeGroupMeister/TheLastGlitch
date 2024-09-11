using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;

    private float _currentHealth;
    Agent _onwer;

    public bool IsHittable { get; set; } = true;


    public UnityEvent OnGetHit;
    public UnityEvent<int> OnGetDamageEvent;
    public UnityEvent OnDeadEvent;


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
        _currentHealth = maxHealth;
    }

    public void AddCurrentHP(int addHealth)
    {
        if (addHealth + _currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }
        else
        {
            _currentHealth += addHealth;
        }



    }

    public float GetCurrentHP()
    {
        return _currentHealth;
    }



    public void TakeDamage(float amount, Vector2 dir, float knockbackPower)
    {
        if (IsHittable)
        {
            OnGetHit?.Invoke();
            if (knockbackPower > 0)
                _onwer.MovementComponent.GetKnockback(dir, knockbackPower);
            _currentHealth -= amount;
            OnGetDamageEvent?.Invoke((int)amount);
            if (_currentHealth <= 0)
            {
                OnDeadEvent?.Invoke();
                _currentHealth = maxHealth;
            }

        }
    }
}
