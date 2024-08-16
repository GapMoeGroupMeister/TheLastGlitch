using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/List/AcceptedList")]
public class AcceptedQuestListSO : ScriptableObject
{
    public List<TestQuestSO> AcceptedList;

    private void OnValidate()
    {
        Debug.Log("되긴하니");
        AcceptedList = new List<TestQuestSO>();
    }





}
