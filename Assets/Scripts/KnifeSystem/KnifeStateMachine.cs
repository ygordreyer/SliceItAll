using UnityEngine;

namespace DefaultNamespace
{
    public class KnifeStateMachine : BaseStateMachine
    {
        public KnifeStateMachine(Camera camera, IKnife handler = null) : base(handler)
        {
            JumpState = new KnifeJump(handler, this);
            FallingState = new KnifeFalling(handler, this);
            IdleState = new KnifeIdle(handler, this);
            
            RegisterState(JumpState);
            RegisterState(FallingState);
            RegisterState(IdleState);
            
            Initialize();
        }
        
        private KnifeJump JumpState { get; }
        private KnifeFalling FallingState { get; }
        private KnifeIdle IdleState { get; }
        
        public void Jump() => PushState<KnifeJump>();
        public void Idle() => PushState<KnifeIdle>();
        public void Fall() => PushState<KnifeFalling>();
        
        
    }
}