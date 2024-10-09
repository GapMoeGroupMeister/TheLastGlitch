using System.Collections.Generic;
using UnityEngine;

public class HackPulse : MonoBehaviour
{
    [SerializeField] private List<AgentMovement> _hackableEnemy;
    [SerializeField] private float _hackRange;
    [SerializeField] private LayerMask _enemyLayer;

    private void Start()
    {
        transform.position = GameManager.Instance.Player.transform.position;
        Hack();
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
            enemy._canMove = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _hackRange);
    }
}