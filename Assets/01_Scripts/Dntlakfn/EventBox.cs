using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventBox : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _warningText;
    public Action action;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetEvent(Action action, string message)
    {
        gameObject.SetActive(true);
        this.action = action;
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
