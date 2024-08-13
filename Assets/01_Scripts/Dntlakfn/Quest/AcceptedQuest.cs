using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class AcceptedQuest : MonoBehaviour
{
    public AcceptedQuestListSO list;
    [SerializeField] protected GameObject _empty;

    private void OnEnable()
    {
        CreatQuest();
    }

    public void CreatQuest()
    {
        foreach (TestQuestSO item in list.AcceptedList)
        {
            QuestControl a = Instantiate(_empty, transform).GetComponent<QuestControl>();
            a._quest = item;
            a.OnCreat?.Invoke();


        }
    }


    
}
