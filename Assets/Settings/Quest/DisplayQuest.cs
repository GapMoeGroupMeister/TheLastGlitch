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
    [SerializeField] protected EventBox eb;
    [SerializeField] protected GameObject _empty;
    
    private void Awake()
    {
        _quests.list.Clear();
        TestQuestSO[] a = _allQuests.list.ToArray();
        Debug.Log(a.Length);
        _quests.list = a.ToList();
        CreatQuest();
    }

    public void CreatQuest()
    {
        if (GetComponentsInChildren<QuestControl>().Length > 0)
            return;
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, 723);
        _quests.list.Sort((x, y) => x.questLevel.CompareTo(y.questLevel));
        for (int i = 0; i < _quests.list.Count; i++)
        {
            _quest = _quests.list[i];
            QuestControl a = Instantiate(_empty, transform).GetComponent<QuestControl>();
            a._quest = _quest;
            a._eb = eb;
            a.OnCreat?.Invoke();
            
            GetComponent<RectTransform>().sizeDelta += new Vector2(400, 0);
        }
        
        
    }



    private void Update()
    {
        
    }
}
