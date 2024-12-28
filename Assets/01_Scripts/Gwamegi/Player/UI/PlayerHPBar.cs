using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] private Image _hpImage;
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
        _hpImage.fillAmount = Health;
        if (_player.IsDie)
        {
            Health = 0;
            return;
        }

        Health = _playerHealth.GetCurrentHP() / _playerHealth.maxHealth;

    }
}
