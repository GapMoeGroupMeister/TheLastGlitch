using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiseBtn : MonoBehaviour
{
    [SerializeField] private float _startScail, _choiseScail, _time;
    [SerializeField] private RectTransform _myBtn;
    [SerializeField] private List<RectTransform> _btnList = new List<RectTransform>();

    public void BtnClick()
    {
        _myBtn.DOScale(_choiseScail , _time);

        foreach (RectTransform rect in _btnList)
        {
            rect.DOScale(_startScail , _time);
        }
    }
}
