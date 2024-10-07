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
            _eb.SetEvent(OnReroll, "상품을 새로고침 하시겠습니까?");
        }
        else
        {
            _eb.SetMessage("돈이 부족합니다.");
        }
    }


}
