using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePassiveFeedBack : Feedback
{
    [SerializeField] private PassiveManager passiveManager;
    public override void PlayFeedback()
    {
        passiveManager.UseTimePassiveSkill();
    }

    public override void StopFeedback()
    {
        
    }
}
