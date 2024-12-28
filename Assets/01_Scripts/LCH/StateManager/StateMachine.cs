using System.Collections.Generic;
using System;

public class StateMachine<T> where T : Enum
{
    public Dictionary<T, State<T>> stateDict = new Dictionary<T, State<T>>();
    public State<T> CurrentState { get; private set; }
    private Agent _agent;

    public void InitInitialize(T state, Agent agent)
    {
        _agent = agent;
        CurrentState = stateDict[state];
        CurrentState.Enter();
    }
    public void ChangeState(T changeState)
    {
<<<<<<< HEAD:Assets/01_Scripts/LCH/StateMachine.cs
        CurrentState.Exit();
        CurrentState = stateDict[changeState];
        CurrentState.Enter();
=======
            CurrentState.Exit();
            CurrentState = stateDict[changeState];
            CurrentState.Enter();
>>>>>>> Develop:Assets/01_Scripts/LCH/StateManager/StateMachine.cs
    }

    public void AddState(T stateEnum, State<T> state)
    {
        stateDict.Add(stateEnum, state);
    }
}
