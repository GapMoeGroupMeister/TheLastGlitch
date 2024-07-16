using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterStore : MonoBehaviour
{
    public UnityEvent OnEnter;
    [SerializeField] protected GameObject storeUI;
    [SerializeField] protected bool a;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       a = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        a = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            storeUI.SetActive(a);
            OnEnter?.Invoke();
        }
    }
}
