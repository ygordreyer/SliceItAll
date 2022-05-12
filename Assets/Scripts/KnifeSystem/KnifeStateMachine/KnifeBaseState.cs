
    public abstract class KnifeBaseState : IState
    {

        protected KnifeBaseState(IKnife handler, BaseStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            Handler = handler;
            IsInitialized = true;
        }

        protected IKnife Handler { get; }
        protected BaseStateMachine StateMachine { get; }
        public bool IsInitialized { get; }

        protected void Enable() { }
        protected virtual void Disable() { }
        protected void DisableCollision() { }
        protected void EnableCollision() { }
        public virtual void OnInitialize() { }
        public virtual void OnEnterState() { }
        public virtual void OnExitState() { }
        public virtual void OnUpdate() { }
        public virtual void OnClear() { }
        public virtual void OnNextState(IState next) { }

    }
