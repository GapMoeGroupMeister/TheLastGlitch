using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DisplayQuest : MonoBehaviour
{
    [SerializeField] protected TestListQuestSO _quests;
    [SerializeField] protected TestQuestSO _quest;
    
    [SerializeField] protected GameObject _empty;

    private void Awake()
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
