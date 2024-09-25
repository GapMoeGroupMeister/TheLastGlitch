using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerChoiseBtn : MonoBehaviour
{
    [SerializeField] private float _startScail, _choiseScail, _time;
    [SerializeField] private RectTransform _myBtn;
    public Image _playerImage;
    public static List<PlayerChoiseBtn> _btnList = new List<PlayerChoiseBtn>();
    public PlayerInfoSO _playerInfoSO;
    public PlayerInfoPanel _playerInfoPanel;

   


    public void BtnClick()
    {
        _myBtn.DOScale(_choiseScail, _time);

        foreach (PlayerChoiseBtn rect in _btnList)
        {
            if (_myBtn != rect.GetComponent<RectTransform>())
            {
                rect.GetComponent<RectTransform>().DOScale(_startScail, _time);
                rect._playerInfoPanel.Hide();
            }

        }

        _playerInfoPanel.Initalize(_playerInfoSO);

    }
}
