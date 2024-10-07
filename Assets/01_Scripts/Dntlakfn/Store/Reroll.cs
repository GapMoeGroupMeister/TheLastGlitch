using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Reroll : MonoBehaviour
{
    public Action OnReroll;
    public UnityEvent reroll;
    public EventBox _eb;

    private void Awake()
    {
        _eb = FindAnyObjectByType<EventBox>();
    }

    public void Click()
    {
        if (Money.money >= 15)
        {
            OnReroll = reroll.Invoke;
            _eb.SetEvent(OnReroll, "��ǰ�� ���ΰ�ħ �Ͻðڽ��ϱ�?");
        }
        else
        {
            _eb.SetMessage("���� �����մϴ�.");
        }
    }


}
