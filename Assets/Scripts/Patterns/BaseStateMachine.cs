using System;
using System.Collections.Generic;

public abstract class BaseStateMachine
{

    protected BaseStateMachine(IStateMachineHandler handler = null) => Handler = handler;

    private readonly Stack<IState> stack = new ();

    private readonly Dictionary<Type, IState> register = new ();

    public IStateMachineHandler Handler { get; }
    
    public bool IsInitialized { get; protected set; }

    public IState Current => PeekState();

    public void RegisterState(IState state)
    {
        if (state == null)
            throw new ArgumentNullException("Null is not a valid state");

        var type = state.GetType();
        register.Add(type, state);
    }

    public void Initialize()
    {
        OnBeforeInitialize();

        foreach (var state in register.Values)
            state.OnInitialize();

        IsInitialized = true;

        OnInitialize();

    }

    protected virtual void OnBeforeInitialize(){}
    protected virtual void OnInitialize(){}

    public void Update() => Current?.OnUpdate();

    public bool IsCurrent<T>() where T : IState => Current?.GetType() == typeof(T);

    public bool IsCurrent(IState state) => Current?.GetType() == state?.GetType();
    
    public IState PeekState() => stack.Count > 0 ? stack.Peek() : null;

    public void PushState<T>(bool isSilent = false) where T : IState
    {
        var stateType = typeof(T);
        var state = register[stateType];
        PushState(state, isSilent);
    }

    public void PushState(IState state, bool isSilent = false)
    {
        var type = state.GetType();
        if (!register.ContainsKey(type))
            throw new ArgumentException("State " + state + " not registered yet.");

        if (stack.Count > 0 && !isSilent)
            Current?.OnExitState();

        stack.Push(state);
        state.OnEnterState();
    }

    public void PopState(bool isSilent = false)
    {
        var state = stack.Pop();
        state.OnExitState();

        if (!isSilent)
            Current?.OnEnterState();
    }

    public virtual void Clear()
    {
        foreach (var state in register.Values)
            state.OnClear();

        stack.Clear();
        register.Clear();
    }


}
