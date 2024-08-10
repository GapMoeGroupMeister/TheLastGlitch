using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFeedBack : Feedback
{
    [SerializeField] private ParticleSystem _particleSystem;

    public override void PlayFeedback()
    {
        Instantiate(_particleSystem,transform.position,Quaternion.identity);
    }

    public override void StopFeedback()
    {
       
    }

   
}
