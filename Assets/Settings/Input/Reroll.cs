using System;
using UnityEngine;
using UnityEngine.Events;

public class Reroll : MonoBehaviour
{
    public Action OnReroll;
    public UnityEvent reroll;
    public EventBox _eb;
    public MessageBox mb;
    public RectTransform canvas;
    public void Click()
    {
        if (FindAnyObjectByType<EventBox>() != null || FindAnyObjectByType<MessageBox>() != null)
        {
            return;
        }
        if (Money.money >= 50)
        {
            OnReroll = mm;
            OnReroll += reroll.Invoke;
            EventBox e = Instantiate(_eb, canvas);
            e.SetEvent(OnReroll, "��ǰ�� ���ΰ�ħ �Ͻðڽ��ϱ�?");
        }
        else
        {
            MessageBox m = Instantiate(mb, canvas);
            m.SetMessage("���� �����մϴ�.");
        }


    }

    public void mm()
    {
        PlayerItemData.Instance.gadgetData.Gold -= 50;
    }


}