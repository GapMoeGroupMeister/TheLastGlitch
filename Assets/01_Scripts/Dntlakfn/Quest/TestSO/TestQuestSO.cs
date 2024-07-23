using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    Clear, Hunt
}


[CreateAssetMenu(menuName = "SO/QuestData")]
public class TestQuestSO : ScriptableObject
{
    public string questName;
    public string questDetail;
    public QuestType questType;
    public int questLevel;

    [Header("Clear")]
    public string targetPlace;
    public bool isClear;

    [Header("Hunt")]
    public string target;
    public int targetNumber;
    public int currentTargetNumber;


    public int award;
}
