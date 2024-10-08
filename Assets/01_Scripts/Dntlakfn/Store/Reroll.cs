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
            _eb.SetEvent(OnReroll, "상품을 새로고침 하시겠습니까?");
        }
        else
        {
            _eb.SetMessage("돈이 부족합니다.");
        }
    }


}
