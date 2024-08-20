using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/List/AllQuest")]

public class AllQuestSO : ScriptableObject
{
    public List<TestQuestSO> list;  
}
