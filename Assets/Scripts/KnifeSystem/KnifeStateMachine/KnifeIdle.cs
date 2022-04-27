
    using UnityEngine;

    public class KnifeIdle : KnifeBaseState
    {
        public KnifeIdle(IKnife handler, BaseStateMachine stateMachine) : base(handler, stateMachine)
        {
        }

        public override void OnEnterState()
        {
            Handler.Rigidbody.isKinematic = true;
        }

        public override void OnUpdate()
        {
            if(Input.GetKeyDown("space") || Input.GetTouch(0).phase == TouchPhase.Began) 
                Handler.Jump();
        }
    }
