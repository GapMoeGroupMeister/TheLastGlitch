using System;
using UnityEngine;

public class State<T> where T : Enum
{
    protected Agent _agent;
    protected int _animBoolHash;
    protected StateMachine<T> stateMachine;
    protected bool _endTriggerCalled;

    public State(Agent _onwer, StateMachine<T> state, string animHashName)
    {
        _agent = _onwer;
        stateMachine = state;
        _animBoolHash = Animator.StringToHash(animHashName);
    }


    public virtual void UpdateState()
    {
        
    }

    public virtual void Enter()
    {
        _agent.AnimatorComponent.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
        _agent.AnimatorComponent.SetBool(_animBoolHash, false);
        _endTriggerCalled = true;
    }
}
