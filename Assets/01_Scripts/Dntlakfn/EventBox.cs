using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventBox : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _warningText;
    public Action action;
    public void SetEvent(Action action, string message)
    {
        this.action = action;
        _warningText.text = message;
    }

    public void Accept()
    {
        action?.Invoke();
        action = null;
    }

    public void Cancel()
    {
        action = null;
        gameObject.SetActive(false);
    }
}
