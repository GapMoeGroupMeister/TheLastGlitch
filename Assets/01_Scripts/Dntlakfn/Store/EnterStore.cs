using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterStore : MonoBehaviour, IInteractive
{
    public UnityEvent OnEnter;
    [SerializeField] protected GameObject storeUI;
    [SerializeField] protected bool isEnter;

    public void OnInteract()
    {
        storeUI.SetActive(isEnter);
        OnEnter?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       isEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEnter = false;
    }
    
    
}
