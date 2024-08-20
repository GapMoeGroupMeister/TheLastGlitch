using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayQuest : MonoBehaviour
{
    [SerializeField] protected TestListQuestSO _quests;
    [SerializeField] protected AllQuestSO _allQuests;
    [SerializeField] protected TestQuestSO _quest;
    
    [SerializeField] protected GameObject _empty;
    
    private void OnEnable()
    {
        _quests.list.Clear();
        TestQuestSO[] a = _allQuests.list.ToArray();
        Debug.Log(a.Length);
        _quests.list = a.ToList();
        CreatQuest();
    }

    public void CreatQuest()
    {
        for(int i = 0; i < _quests.list.Count; i++)
        {
            _quest = _quests.list[i];
            QuestControl a = Instantiate(_empty, transform).GetComponent<QuestControl>();
            a._quest = _quest;
            a.OnCreat?.Invoke();
        }
        
        
    }



    private void Update()
    {
        
    }
}
