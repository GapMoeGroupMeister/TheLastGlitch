using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;

public class PassiveManager : MonoSingleton<PassiveManager>
{
    public List<PassiveSO> HavePassiveList = new List<PassiveSO>();

    public NotifyValue<List<PassiveSO>> NotifyUsePassiveList = new NotifyValue<List<PassiveSO>>();

    public Player player;

    private void Start()
    {
        player = GameManager.Instance.Player;
        StartCoroutine(PassiveTimer(2));
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            List<PassiveSO> list = new List<PassiveSO>();
            list = HavePassiveList;

            UsePassiveSkill(list);
        }
    }


    public void AddPassive()
    {
        NotifyUsePassiveList.Value = HavePassiveList;
    }


    public void UseTimePassiveSkill()
    {
        foreach (PassiveSO item in NotifyUsePassiveList.Value)
        {
            if (item.type == PATEnum.Time)
            {
                item.Skill(player);
            }
        }
    }

    private IEnumerator PassiveTimer(float time)
    {
        while (true)
        {
            UseTimePassiveSkill();
            Debug.Log("타임 패시브 실행");
            yield return new WaitForSeconds(time);
        }
    }

    public void UseAttackPassiveSkill()
    {
        foreach (PassiveSO item in NotifyUsePassiveList.Value)
        {
            if (item.type == PATEnum.Attack)
                item.Skill(player);
        }
    }
    public void UseHitassiveSkill()
    {
        foreach (PassiveSO item in NotifyUsePassiveList.Value)
        {
            if (item.type == PATEnum.Hit)
                item.Skill(player);
        }
    }

    public void UsePassiveSkill(List<PassiveSO> passives)
    {
        NotifyUsePassiveList.Value = passives;
    }
}
