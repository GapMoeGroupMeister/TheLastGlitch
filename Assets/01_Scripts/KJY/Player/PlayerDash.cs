using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDash : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;
    [SerializeField] private AgentMovement _player;

    [SerializeField] private float _dashDistance = 1f;

    private bool _isDash = false;

    private void Awake()
    {
        _input.OnDashEvent += Dash;
    }

    private void OnDisable()
    {
        _input.OnDashEvent -= Dash;
    }

    private void Dash()
    {
        if (!WeaponCoolTime.instance._attack)
        {
            if(!_isDash)
            {
                Debug.Log("Dash");
                if (_player._xMove < 0)
                {
                    transform.DOMoveX(transform.position.x - _dashDistance, 0.1f);
                    StartCoroutine(DashCoolTime());
                }

                if (_player._xMove > 0)
                {
                    transform.DOMoveX(transform.position.x + _dashDistance, 0.1f);
                    StartCoroutine(DashCoolTime());
                }
            }
        }
    }

    private IEnumerator DashCoolTime()
    {
        _isDash = true;
        yield return new WaitForSeconds(0.75f);
        _isDash = false;
    }
}
