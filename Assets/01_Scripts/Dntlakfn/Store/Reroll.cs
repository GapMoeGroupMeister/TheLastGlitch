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
        if (Money.money >= 50)
        {
            OnReroll = mm;
            OnReroll += reroll.Invoke;
            EventBox e = Instantiate(_eb, canvas);
            e.SetEvent(OnReroll, "상품을 새로고침 하시겠습니까?");
        }
        else
        {
            MessageBox m = Instantiate(mb, canvas);
            m.SetMessage("돈이 부족합니다.");
        }


    }

    public void mm()
    {
        PlayerItemData.Instance.gadgetData.Gold -= 50;
    }


}
