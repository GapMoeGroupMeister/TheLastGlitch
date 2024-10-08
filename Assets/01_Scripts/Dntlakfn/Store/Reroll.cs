using System;
using UnityEngine;
using UnityEngine.Events;

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
        if (Money.money >= 50)
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
