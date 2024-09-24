using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBtn : MonoBehaviour
{
    [SerializeField] private PlayerInfoPanel _playerInfoPanel;
    [SerializeField] private Image _image;
    private PlayerInfoSO _playerInfoSO;
    public PlayerTypeEnum playerTypeEnum;

    [SerializeField] private FinalPlayerSelectBtn _finalConfirmation;

    private void Start()
    {
        _playerInfoPanel.OnPlayerSelectEvent += OnPlayerSelect;
    }

    private void OnPlayerSelect(PlayerTypeEnum playerType, PlayerInfoSO sO)
    {
        _image.sprite = sO.playerSpreite;
        _playerInfoSO = sO;
        playerTypeEnum = playerType;

        if (playerType == PlayerTypeEnum.None)
            transform.GetComponent<Button>().interactable = false;
        else
            transform.GetComponent<Button>().interactable = true;
    }

    public void SelectPlayer()
    {
        _finalConfirmation.gameObject.SetActive(true);
        _finalConfirmation.Initialize(playerTypeEnum, _playerInfoSO);

        foreach (PlayerChoiseBtn item in PlayerChoiseBtn._btnList)
        {
            item.GetComponent<Button>().interactable = false;
        }
    }
}
