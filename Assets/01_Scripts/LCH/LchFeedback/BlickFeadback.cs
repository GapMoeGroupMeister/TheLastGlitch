using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlickFeadback : Feedback
{
    [SerializeField] private SpriteRenderer _targetRender;
    [SerializeField] private float _fishTime = 0.1f;

    private Material _trgetMat;

    private readonly int _isHitHash = Shader.PropertyToID("_IsHit");

    private void Awake()
    {
        _trgetMat = _targetRender.material;
    }

    public override void PlayFeedback()
    {
        _trgetMat.SetInt(_isHitHash, 1);
        StartCoroutine(DelayBilnk());
    }

    private IEnumerator DelayBilnk()
    {
        yield return new WaitForSeconds(_fishTime);
        _trgetMat.SetInt(_isHitHash, 0);
    }

    public override void StopFeedback()
    {
        StopAllCoroutines();
        _trgetMat.SetInt(_isHitHash, 0);
    }
}
