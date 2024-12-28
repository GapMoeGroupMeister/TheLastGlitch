using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEffectFeedBack : Feedback
{

    [SerializeField] private string _effectName;
    [SerializeField] private float _rand;

    public override void PlayFeedback()
    {
        PoolingEffect effect = PoolManager.Instance.Pop(_effectName) as PoolingEffect;
        effect.transform.position = new Vector3(transform.position.x + Random.Range(-_rand, _rand), transform.position.y + Random.Range(-_rand, _rand));
    }

    public override void StopFeedback()
    {
    }
}
