using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    #region
    public AgentMovement MovementCompo { get; private set; }
    public Health HealthCompo { get; private set; }
    #endregion

    public bool isDead { get; private set; }
    
    protected virtual void Awake()
    {
        MovementCompo = GetComponent<AgentMovement>();
        MovementCompo.Initialize(this);
        HealthCompo = GetComponent<Health>();
        HealthCompo.Initialize(this);
    }
}
