using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterStore : MonoBehaviour, IInteractive
{
    public UnityEvent OnEnter;
    [SerializeField] protected GameObject storeUI;
    [SerializeField] protected bool isEnter;

    public void OnDisconnect()
    {
        storeUI.SetActive(false);
    }

    public void OnInteract()
    {
        storeUI.SetActive(true);
        OnEnter?.Invoke();
    }

   
    
    
}
