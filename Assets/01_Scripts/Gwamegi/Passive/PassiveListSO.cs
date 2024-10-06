using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Passive/PassiveListSO")]
public class PassiveListSO : ScriptableObject
{
    public List<PassiveSO> passiveSOList = new List<PassiveSO>();
}
