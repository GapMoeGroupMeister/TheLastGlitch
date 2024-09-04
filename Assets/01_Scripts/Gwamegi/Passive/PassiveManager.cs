using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;

public class PassiveManager : MonoBehaviour
{
    public List<PassiveSO> HavePassiveList = new List<PassiveSO>();
    public List<PassiveSO> UsePassiveList = new List<PassiveSO>();

    public Player player;

    private void Start()
    {
        player = GameManager.Instance.Player;
        UseTimePassiveSkill();

    }


    public void UseTimePassiveSkill()
    {
        foreach (PassiveSO item in UsePassiveList)
        {
            if (item.type == PATEnum.Time)
            {
                StartCoroutine(PassiveTimer(item.time, item));
            }
        }
    }

    private IEnumerator PassiveTimer(float time, PassiveSO item)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            item.Skill(player);
            Debug.Log("타임 패시브 실행");
        }
    }

    public void UseAttackPassiveSkill()
    {
        foreach (PassiveSO item in UsePassiveList)
        {
            if (item.type == PATEnum.Attack)
                item.Skill(player);
        }
    }
    public void UseHitassiveSkill()
    {
        foreach (PassiveSO item in UsePassiveList)
        {
            if (item.type == PATEnum.Hit)
                item.Skill(player);
        }
    }
}
