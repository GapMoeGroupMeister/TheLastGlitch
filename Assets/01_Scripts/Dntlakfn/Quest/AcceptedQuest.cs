using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class AcceptedQuest : MonoBehaviour
{
    public AcceptedQuestListSO list;
    [SerializeField] protected EventBox eb;
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
            a._eb = eb;
            a.OnCreat?.Invoke();


        }
    }


    
}
