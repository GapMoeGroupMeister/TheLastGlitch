using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/List/AllQuest")]
public class AllQuestSO : ScriptableObject
{
    public static List<TestQuestSO> list;


    private void OnValidate()
    {
        list = new List<TestQuestSO>();
    }
}
