using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventBox : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _warningText;
    public Action action;
    private PlayerInteract interact;

    private void OnEnable()
    {
        interact = FindAnyObjectByType<PlayerInteract>();

    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cancel();
        }
    }
    public void SetEvent(Action action, string message)
    {
        
        this.action = action;
        _warningText.text = message;
    }

    public void Accept()
    {
        action?.Invoke();
        action = null;

        Destroy(gameObject);
    }

    public void Cancel()
    {
        action = null;

        Destroy(gameObject);

    }

}
