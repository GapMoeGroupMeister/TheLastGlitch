using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class PlayerChoiseBtn : MonoBehaviour
{
    public float YScail;
    public float time;

    [SerializeField] private RectTransform _playerInfoPanel;
    [SerializeField] private PlayerInfoSO _playerInfoSO;

    public UnityEvent<PlayerInfoSO> OnPlayerInfoPanelEnterEvent;

    public void InfoPanelEnter()
    {
        OnPlayerInfoPanelEnterEvent?.Invoke(_playerInfoSO);
        _playerInfoPanel.DOScaleY(YScail, time);
    }

}
