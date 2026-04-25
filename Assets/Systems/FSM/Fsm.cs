using System;
using System.Collections.Generic;

public class Fsm
{
    private FsmState Current { get; set; }
    private Dictionary<Type, FsmState> _states = new();
    public void AddState(FsmState state)
    {
        _states.Add(state.GetType(), state);
    }
    public T GetState<T>() where T : FsmState
    {
        return (T)_states[typeof(T)];
    }

    public void SetState<T>() where T : FsmState
    {
        Type type = typeof(T);
        if (Current?.GetType() == type)
        {
            return;
        }
        if (_states.TryGetValue(type, out FsmState newState))
        {
            Current?.Exit();
            Current = newState;
            Current.Enter();
        }
    }
    public void Update()
    {
        Current?.Update();
    }

}