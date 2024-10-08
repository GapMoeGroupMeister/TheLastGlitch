using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
    
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
    public TextMeshProUGUI playerActiveSkillDescTMP;

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
        }
    }


    public void Initalize(PlayerInfoSO playerInfo)
    {
        penal.gameObject.SetActive(true);
        sprite.sprite = playerInfo.playerSpreite;
        playerNameTMP.text = $"플레이어 이름 : {playerInfo.playerName}";
        playerStatInfoTMP.text = StatText(playerInfo).Replace("\\n", "\n").Replace("\\t", "\t");
        playerPassiveDescTMP.text = $"고유 패시브 : {playerInfo.playerPassiveDesc}";
        playerActiveSkillDescTMP.text = $"액티브 스킬 : {playerInfo.playerActiveSkillDesc}";

        currentPlayer = playerInfo.playerType;
        OnPlayerSelectEvent?.Invoke(currentPlayer, playerInfo);
    }

    public string StatText(PlayerInfoSO playerInfo)
    {
        return $"최대체력 : {playerInfo.maxHealth} \n이동속도 : {playerInfo.moveSpeed} \n공격력 : {playerInfo.atkPower}\n크리티컬 데미지 : {playerInfo.critDamage}\n크리티컬 확률 : {playerInfo.critProbability}";
    }

    public void Hide()
    {
        penal.gameObject.SetActive(false);
        sprite.sprite = default;
        playerNameTMP.text = default;
        playerStatInfoTMP.text = default;
        playerPassiveDescTMP.text = default;
        playerActiveSkillDescTMP.text = default;
    }
}
;