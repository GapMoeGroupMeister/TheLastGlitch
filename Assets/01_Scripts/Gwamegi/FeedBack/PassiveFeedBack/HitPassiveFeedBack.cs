using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPassiveFeedBack : Feedback
{
    [SerializeField] private PassiveManager _passiveManager;
    public override void PlayFeedback()
    {
        _passiveManager.UseHitSkill();
    }

    public override void StopFeedback()
    {
        
    }
}
