using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1ActiveSkill : MonoBehaviour
{
    [field: SerializeField] private InputReader _input;

    private AgentMovement _agentMovement;

    private bool _usingActive;

    private void Awake()
    {
        _agentMovement = GetComponentInParent<AgentMovement>();

        _input.OnActiveSkillEvent += UseActiveSkill;
    }

    private void UseActiveSkill()
    {
        if(!_usingActive)
        {
            StartCoroutine(Player1Active());
        }
    }

    private IEnumerator Player1Active()
    {
        _usingActive = true;
        Time.timeScale = 0.25f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        _agentMovement.moveSpeed *= 4;
        _agentMovement.extraGravity *= 4;
        yield return new WaitForSeconds(1f);
        _usingActive = false;
        Time.timeScale = 1f;
        _agentMovement.moveSpeed /= 4;
        _agentMovement.extraGravity /= 4;
    }
}
