using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestControl : MonoBehaviour
{
    public EventBox _eb;

    [SerializeField] protected TestListQuestSO quests;
    [SerializeField] protected AcceptedQuestListSO acceptedQuests;
    public UnityEvent OnCreat;
    public Action OnAccept;

    
    [field:SerializeField]
    public TestQuestSO _quest { get; set; }

    [SerializeField] protected TextMeshProUGUI _name;
    [SerializeField] protected TextMeshProUGUI _detail;
    [SerializeField] protected TextMeshProUGUI _level;
    [SerializeField] protected TextMeshProUGUI _contents;

    private void Awake()
    {
        _eb = FindAnyObjectByType<EventBox>();
    }

    private void Update()
    {
        CheckComplete();
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }


    public void UpdateQuest()
    {
        _name.text = _quest.questName;
        _detail.text = _quest.questDetail;
        _level.text = "��õ ���� : " + _quest.questLevel;
        if(_quest.questType == QuestType.Clear)
        {
            _contents.text = $"\"{_quest.targetPlace}\" Ŭ����";

        }
        else if(_quest.questType == QuestType.Hunt)
        {
            _contents.text = $"{_quest.target}\n{_quest.currentTargetNumber}/{_quest.targetNumber}";
        }
    }

    public void QuestClear()
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

    public void AcceptQuest()
    {
        
        
        quests.list.Remove(_quest);

        EnterStage.map = _quest.targetPlace;
        Debug.Log(EnterStage.map);
        acceptedQuests.AcceptedList.Add(_quest);
        quests.list.Remove(_quest);
        Destroy(gameObject);
        
        
    }

    public void RemoveAcceptedQuest()
    {
        acceptedQuests.AcceptedList.Remove(_quest);
        quests.list.Add(_quest);
        quests.list.Sort((x, y) =>
        {
            if(x.questLevel <= y.questLevel)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        });
        Destroy(gameObject);
    }

    public void Click()
    {
        
        if (acceptedQuests.AcceptedList.Contains(_quest))
        {
            OnAccept = RemoveAcceptedQuest;
            Instantiate(_eb).SetEvent(OnAccept, "����Ʈ�� ����Ͻðڽ��ϱ�?");
        }
        else
        {
            if (acceptedQuests.AcceptedList.Count == 0)
            {
                OnAccept = AcceptQuest;
                Instantiate(_eb).SetEvent(OnAccept, "����Ʈ�� �����ðڽ��ϱ�?");
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
                transform.Find("BackGround").GetComponent<Image>().color = Color.green;
                _name.color = Color.green;
                _detail.color = Color.green;
                _contents.color = Color.green;

            }

        }
        else if (_quest.questType == QuestType.Hunt)
        {
            if(_quest.targetNumber <= _quest.currentTargetNumber)
            {
                GetComponent<Image>().color = Color.green;
                transform.Find("BackGround").GetComponent<Image>().color = Color.green;
                _name.color = Color.green;
                _detail.color = Color.green;
                _contents.color = Color.green;
            }
        }
    }
}
