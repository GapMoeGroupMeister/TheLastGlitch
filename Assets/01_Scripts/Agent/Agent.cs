using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    #region Component
    public AgentMovement MovementComponent { get; protected set; }
    public Animator AnimatorComponent { get; protected set; }
    public Health HealthComponent { get; protected set; }
    #endregion

    public bool IsDie { get; protected set; }
    protected float _timeInTheAir;
    protected virtual void Awake()
    {
        MovementComponent = GetComponent<AgentMovement>();
        MovementComponent.Initialize(this);

        AnimatorComponent = transform.Find("Visual").GetComponent<Animator>();

        HealthComponent = GetComponent<Health>();
        HealthComponent.Initialize(this);
    }
    public abstract void SetDeadState();
    #region Flip
    public bool IsFacingRight()
    {
        return Mathf.Approximately(transform.eulerAngles.y, 0);

    }
    public void HandleSpriteFlip(Vector3 targerPosition)
    {
        if (targerPosition.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
        else if (targerPosition.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    public void PlayerFlip(float xFlip)
    {
        if (xFlip > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (xFlip < 0)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
    }
    #endregion

}
