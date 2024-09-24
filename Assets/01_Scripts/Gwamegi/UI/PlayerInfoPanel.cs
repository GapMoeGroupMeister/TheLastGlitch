using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInfoPanel : MonoBehaviour
{
    public RectTransform createPlayerInfoPanel;
    public RectTransform createPlayerIcon;
    public List<PlayerInfoSO> playerInfoSOList = new List<PlayerInfoSO>();

    public RectTransform penal;
    public Image sprite;
    public TextMeshProUGUI playerNameTMP;
    public TextMeshProUGUI playerStatInfoTMP;
    public TextMeshProUGUI playerPassiveDescTMP;

    public PlayerTypeEnum currentPlayer;
    public Action<PlayerTypeEnum, PlayerInfoSO> OnPlayerSelectEvent;

    private void Start()
    {
        createPlayerIcon.gameObject.SetActive(false);

        foreach (PlayerInfoSO item in playerInfoSOList)
        {
            RectTransform icon = Instantiate(createPlayerIcon, createPlayerInfoPanel);
            icon.gameObject.SetActive(true);

            icon.GetComponent<PlayerChoiseBtn>()._playerInfoSO = item;
            icon.GetComponent<PlayerChoiseBtn>()._playerImage.sprite = item.playerSpreite;
            PlayerChoiseBtn._btnList.Add(icon.GetComponent<PlayerChoiseBtn>());

            

            //icon.Find("PlayerIcon").GetComponent<Image>().sprite = item.playerSpreite;

        }
    }


    public void Initalize(PlayerInfoSO playerInfo)
    {
        penal.gameObject.SetActive(true);
        sprite.sprite = playerInfo.playerSpreite;
        playerNameTMP.text = playerInfo.playerName;
        playerStatInfoTMP.text = playerInfo.playerStatInfo;
        playerPassiveDescTMP.text = playerInfo.playerPassiveDesc;

        currentPlayer = playerInfo.playerType;
        OnPlayerSelectEvent?.Invoke(currentPlayer, playerInfo);
    }

    public void Hide()
    {
        penal.gameObject.SetActive(false);
        sprite.sprite = default;
        playerNameTMP.text = default;
        playerStatInfoTMP.text = default;
        playerPassiveDescTMP.text = default;
    }
}
