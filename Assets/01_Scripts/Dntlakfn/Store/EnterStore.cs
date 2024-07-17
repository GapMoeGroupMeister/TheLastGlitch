using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterStore : MonoBehaviour
{
    public UnityEvent OnEnter;
    [SerializeField] protected GameObject storeUI;
    [SerializeField] protected bool isEnter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       isEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEnter = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            storeUI.SetActive(isEnter);
            OnEnter?.Invoke();
        }
    }
}
