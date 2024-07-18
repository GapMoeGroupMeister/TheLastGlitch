using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestControl : MonoBehaviour
{
    [SerializeField] protected TestListQuestSO quests;
    public UnityEvent OnCreat;


    [field:SerializeField]
    public TestQuestSO _quest { get; set; }

    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _detail;
    [SerializeField] protected TextMeshProUGUI _contents;


    public void UpdateQuest()
    {
        _name.text = _quest.questName;
        _detail.text = _quest.questDetail;
        if(_quest.questType == QuestType.Clear)
        {
            _contents.text = $"{_quest.targetPlace}";

        }
        else if(_quest.questType == QuestType.Hunt)
        {
            _contents.text = $"{_quest.target}\n{_quest.currentTargetNumber}/{_quest.targetNumber}";
        }
    }

    public void RemoveQuest()
    {
        if (_quest.questType == QuestType.Clear)
        {
            if (_quest.isClear)
            {
                quests.list.Remove(_quest);
                Destroy(gameObject);
            }

        }
        else if (_quest.questType == QuestType.Hunt)
        {
            if (_quest.targetNumber <= _quest.currentTargetNumber)
            {
                quests.list.Remove(_quest);
                Destroy(gameObject);
            }
        }
        
    }



    public void CheckComplete()
    {
        if (_quest.questType == QuestType.Clear)
        {
            if(_quest.isClear)
            {
                GetComponent<Image>().color = Color.green;
                _name.color = Color.green;
                _contents.color = Color.green;
                
            }

        }
        else if (_quest.questType == QuestType.Hunt)
        {
            if(_quest.targetNumber <= _quest.currentTargetNumber)
            {
                GetComponent<Image>().color = Color.green;
                _name.color = Color.green;
                _contents.color = Color.green;
            }
        }
    }
}