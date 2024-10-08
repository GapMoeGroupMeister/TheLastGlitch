using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerDash : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;
    [SerializeField] private AgentMovement _player;

    private TrailRenderer _trail;

    [SerializeField] private float _dashDistance = 1f;

    private bool _isDash = false;

    private DG.Tweening.Sequence dashSequence;

    private void Awake()
    {
        _trail = GetComponent<TrailRenderer>();
        _input.OnDashEvent += Dash;
    }

    private void Start()
    {
        _trail.emitting = false;
    }

    private void OnDisable()
    {
        //_input.OnDashEvent -= Dash;
    }

    private void Dash()
    {
        if (!WeaponCoolTime.instance._attack)
        {
            if(!_isDash)
            {
                if (_player._xMove < 0)
                {
                    dashSequence = DOTween.Sequence();
                    dashSequence.AppendCallback(() => _trail.emitting = true);
                    dashSequence.Append(transform.DOMoveX(transform.position.x - _dashDistance, 0.1f));
                    dashSequence.AppendCallback(() => _trail.emitting = false);
                    StartCoroutine(DashCoolTime());
                }

                if (_player._xMove > 0)
                {
                    dashSequence = DOTween.Sequence();
                    dashSequence.AppendCallback(() => _trail.emitting = true);
                    dashSequence.Append(transform.DOMoveX(transform.position.x + _dashDistance, 0.1f));
                    dashSequence.AppendCallback(() => _trail.emitting = false);
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
