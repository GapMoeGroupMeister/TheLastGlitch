using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
    
public class PlayerInfoPanel : MonoBehaviour
{
    public Image sprite;
    public TextMeshProUGUI playerNameTMP;
    public TextMeshProUGUI playerStatInfoTMP;
    public TextMeshProUGUI playerPassiveDescTMP;
    public TextMeshProUGUI playerActiveSkillDescTMP;

    public Button SelectBtn;
    public PlayerInfoSO nonePlayerInfo;
    public void Initalize(PlayerInfoSO playerInfo)
    {
        sprite.sprite = playerInfo.playerSpreite;
        playerNameTMP.text = $"플레이어 이름 : {playerInfo.playerName}";
        playerStatInfoTMP.text = StatText(playerInfo).Replace("\\n", "\n").Replace("\\t", "\t");
        playerPassiveDescTMP.text = $"고유 패시브 : {playerInfo.playerPassiveDesc}";
        playerActiveSkillDescTMP.text = $"액티브 스킬 : {playerInfo.playerActiveSkillDesc}";

        if(nonePlayerInfo == playerInfo)
            SelectBtn.interactable = false;
        else
            SelectBtn.interactable = true;
    }

    public string StatText(PlayerInfoSO playerInfo)
    {
        return $"최대체력 : {playerInfo.maxHealth} \n이동속도 : {playerInfo.moveSpeed} \n공격력 : {playerInfo.atkPower}\n크리티컬 데미지 : {playerInfo.critDamage}\n크리티컬 확률 : {playerInfo.critProbability}";
    }

    public void Hide()
    {
        sprite.sprite = default;
        playerNameTMP.text = default;
        playerStatInfoTMP.text = default;
        playerPassiveDescTMP.text = default;
        playerActiveSkillDescTMP.text = default;
    }
}
;