using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterQuest : MonoBehaviour, IInteractive
{
    public UnityEvent OnEnter;
    [SerializeField] protected GameObject QuestUI;
    [SerializeField] protected bool isEnter;

    public void OnDisconnect()
    {
        QuestUI.SetActive(false);
    }

    public void OnInteract()
    {
        QuestUI.SetActive(true);
        OnEnter?.Invoke();
    }

   

    
}
