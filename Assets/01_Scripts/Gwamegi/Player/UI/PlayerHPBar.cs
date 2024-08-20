using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] private RectTransform _hpBar;

    private Player _player; 
    private Health _playerHealth;

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
            else if (value >= 1)
            {
                _health = 1;
            }
            else if (value <= 0)
            {
                _health = 0;
            }
        }

    }

    private void Start()
    {
        _player = GameManager.Instance.Player;
        _playerHealth = _player.GetComponent<Health>();
    }

    private void Update()
    {

        _hpBar.localScale = new Vector3(Health, 1, 1);
        if (_player.IsDie)
        {
            Health = 0;
            return;
        }

        Health = _playerHealth.GetCurrentHP() / _playerHealth._maxHealth;

    }
}
