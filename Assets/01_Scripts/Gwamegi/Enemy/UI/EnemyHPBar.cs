using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    [SerializeField] private GameObject _hpBar;

    private Enemy _enemy;

    private Health _enemyHealth;

    private float _health;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value >= 0 && value <= 1)
                _health = value;
            else if(value >= 1)
            {
                _health = 1;
            }
            else if (value <= 0)
            {
                _health = 0;
            }
        }

    }

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        _enemyHealth = GetComponentInParent<Health>();
    }

    private void Update()
    {

        _hpBar.transform.localScale = new Vector3(Health, 1, 1);
        if (_enemy.IsDie) 
        {
            Health = 0;
            return;
                }

        Health = _enemyHealth.GetCurrentHP() / _enemyHealth.maxHealth;
        Flip();

    }

    private void Flip()
    {
        transform.localScale = new Vector3(-_enemy.gameObject.transform.localScale.x, 1,1);
    }
}
