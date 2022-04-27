
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

        protected void Enable()
        {
            /*
            if (Handler.Collider)
                EnableCollision();
            if (Handler.Rigidbody)
                Handler.Rigidbody.Sleep();
            */
        }

        protected virtual void Disable()
        {
            /*
            DisableCollision();
            Handler.Rigidbody.Sleep();
            MakeRenderNormal();
            foreach (var renderer in Handler.Images)
            {
                var myColor = renderer.color;
                myColor.a = GlobalKnifeData.DisabledAlpha;
                renderer.color = myColor;
            }
            */
        }

        protected void DisableCollision()
        {
            //Handler.Collider.enabled = false;
        }

        protected void EnableCollision()
        {
            //Handler.Collider.enabled = true;
        }


        public virtual void OnInitialize() { }
        public virtual void OnEnterState() { }
        public virtual void OnExitState() { }
        public virtual void OnUpdate() { }
        public virtual void OnClear() { }
        public virtual void OnNextState(IState next) { }

    }
