using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDash : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    [SerializeField] private GameObject _player;
    [SerializeField] private float _dashDistance = 1f;

    private void Awake()
    {
        _input.OnDashEvent += Dash;
    }

    private void Dash()
    {
        if (!WeaponCoolTime.instance._attack)
        {
            if (_player.transform.localScale.x < 0)
            {
                transform.DOMoveX(transform.position.x - _dashDistance, 0.1f);
            }

            if (_player.transform.localScale.x > 0)
            {
                transform.DOMoveX(transform.position.x + _dashDistance, 0.1f);
            }
        }
        
    }
}
