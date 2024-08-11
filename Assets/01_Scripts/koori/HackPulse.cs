using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackPulse : MonoBehaviour
{
    [SerializeField] private List<AgentMovement> _hackableEnemy;
    [SerializeField] private float _hackRange;
    [SerializeField] private float _hackingTime;
    [SerializeField] private LayerMask _enemyLayer; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            Hack();
        }
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

     
        StartCoroutine(HackEnemies(_hackingTime));
    }

    private IEnumerator HackEnemies(float duration)
    {
      
        foreach (AgentMovement enemy in _hackableEnemy)
        {
            enemy.StopImmediately(true);
            enemy._canMove = false; 
        }

        yield return new WaitForSeconds(duration);

        
        foreach (AgentMovement enemy in _hackableEnemy)
        {
            enemy._canMove = true;
        }
    }

#if UNITY_EDITOR    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _hackRange);
    }
#endif
}