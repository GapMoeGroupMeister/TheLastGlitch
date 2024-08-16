using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour
{
    public List<PassiveSO> HavePassiveList = new List<PassiveSO>();
    public List<PassiveSO> UsePassiveList = new List<PassiveSO>();

    public Player player;

    private void Start()
    {
        player = GameManager.Instance.Player;
    }


    public void UseTimeSkill()
    {
        foreach (PassiveSO item in UsePassiveList)
        {
            if (item.type == PATEnum.Time)
                item.Skill(player);
        }
    }
    public void UseAttackSkill()
    {
        foreach (PassiveSO item in UsePassiveList)
        {
            if (item.type == PATEnum.Attack)
                item.Skill(player);
        }
    }
    public void UseHitSkill()
    {
        foreach (PassiveSO item in UsePassiveList)
        {
            if (item.type == PATEnum.Hit)
                item.Skill(player);
        }
    }
}
