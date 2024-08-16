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

    private void Start()
    {
        _quests.list = AllQuestSO.list;
        CreatQuest();
    }
    
    private void OnEnable()
    {
        CreatQuest();
    }

    public void CreatQuest()
    {
        for(int i = _quest.questLevel-1; i < _quest.questLevel+5; i++)
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
