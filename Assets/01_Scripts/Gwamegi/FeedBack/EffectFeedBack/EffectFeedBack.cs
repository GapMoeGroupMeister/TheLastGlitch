using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFeedBack : Feedback
{
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private string _effectName;

    public override void PlayFeedback()
    {
        PoolingEffect effect = PoolManager.Instance.Pop(_effectName) as PoolingEffect;
        effect.transform.position = transform.position;
        
        
        
    }


    public override void StopFeedback()
    {
       
    }

   
}
