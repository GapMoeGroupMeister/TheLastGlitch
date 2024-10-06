using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackPulse : GadgetParent
{
    [SerializeField] private List<AgentMovement> _hackableEnemy;
    [SerializeField] private float _hackRange;
    [SerializeField] private LayerMask _enemyLayer;

    private void Start()
    {
        _type = GadgetType.hackPulse; // HackPulse의 타입 설정
        _isUse += Hack; // UseGadget() 함수 호출 시 Hack() 함수 실행
    }

    private void Hack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _hackRange, _enemyLayer);

        _hackableEnemy.Clear();

        foreach (Collider2D collider in colliders)
        {
            AgentMovement agentMovement = collider.GetComponent<AgentMovement>();
            if (agentMovement != null)
            {
                _hackableEnemy.Add(agentMovement);
            }
        }

        foreach (AgentMovement enemy in _hackableEnemy)
        {
            enemy.StopImmediately(true);
            enemy._xMove = 0;
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _hackRange);
    }
#endif

    // UseGadget() 함수는 GadgetParent에서 상속받아 사용
}