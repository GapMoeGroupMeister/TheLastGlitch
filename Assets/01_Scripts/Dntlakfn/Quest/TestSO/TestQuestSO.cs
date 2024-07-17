using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    Clear, Hunt, All
}


[CreateAssetMenu(menuName = "SO/QuestData")]
public class TestQuestSO : ScriptableObject
{
    public string questName;
    public string questContents;
    public QuestType questType;

    [Header("Clear")]
    public string targetPlace;
    public bool isClear;

    [Header("Hunt")]
    public string target;
    public int targetNumber;

}
