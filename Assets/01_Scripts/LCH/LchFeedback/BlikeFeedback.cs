using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlikeFeedback : Feedback
{
    [SerializeField] private Sprite _blikeSprite;
    [SerializeField] private Sprite _basicSprite;
    [SerializeField] private float _flashTime = 0.2f;
    [SerializeField] private SpriteRenderer _targetRender;

  
    public override void PlayFeedback()
    {
        _targetRender.sprite = _blikeSprite;
        StartCoroutine(DelayBilnk());
    }

    private IEnumerator DelayBilnk()
    {
        yield return new WaitForSeconds(_flashTime);
        _targetRender.sprite = _basicSprite;
    }

    public override void StopFeedback()
    {
        StopAllCoroutines();
        _targetRender.sprite = _basicSprite;
    }
}
