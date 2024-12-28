using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPassiveFeedBack : Feedback
{
    [SerializeField] private PassiveManager _passiveManager;
    public override void PlayFeedback()
    {
        _passiveManager.UseAttackPassiveSkill();
    }

    public void PassivePlay()
    {
        _passiveManager.UseAttackPassiveSkill();

    }

    public override void StopFeedback()
    {
        
    }
}
