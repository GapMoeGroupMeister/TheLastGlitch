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
        playerNameTMP.text = $"�÷��̾� �̸� : {playerInfo.playerName}";
        playerStatInfoTMP.text = StatText(playerInfo).Replace("\\n", "\n").Replace("\\t", "\t");
        playerPassiveDescTMP.text = $"���� �нú� : {playerInfo.playerPassiveDesc}";
        playerActiveSkillDescTMP.text = $"��Ƽ�� ��ų : {playerInfo.playerActiveSkillDesc}";

        if(nonePlayerInfo == playerInfo)
            SelectBtn.interactable = false;
        else
            SelectBtn.interactable = true;
    }

    public string StatText(PlayerInfoSO playerInfo)
    {
        return $"�ִ�ü�� : {playerInfo.maxHealth} \n�̵��ӵ� : {playerInfo.moveSpeed} \n���ݷ� : {playerInfo.atkPower}\nũ��Ƽ�� ������ : {playerInfo.critDamage}\nũ��Ƽ�� Ȯ�� : {playerInfo.critProbability}";
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