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

    private void Start()
    {
        interact = FindAnyObjectByType<PlayerInteract>();
        gameObject.SetActive(false);
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
        gameObject.SetActive(true);
        this.action = action;
        _warningText.text = message;
    }

    public void SetMessage(string message)
    {
        gameObject.SetActive(true);
        action = null;
        _warningText.text = message;
    }

    public void Accept()
    {
        action?.Invoke();
        action = null;

        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        action = null;

        gameObject.SetActive(false);
    }

}
