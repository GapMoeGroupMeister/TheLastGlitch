using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPassiveFeedBack : Feedback
{
    [SerializeField] private PassiveManager _passiveManager;
    public override void PlayFeedback()
    {
        _passiveManager.UseAttackSkill();
    }

    public override void StopFeedback()
    {
        
    }
}
