
    using System;
    using UnityEngine;

    public class KnifeFalling : KnifeBaseState
    {
        public KnifeFalling(IKnife handler, BaseStateMachine stateMachine) : base(handler, stateMachine) { }

        private bool AllowJump = false;
        
        public override void OnUpdate()
        {
            if (HasFinishedRotation())
                ResetGroundPosition();
            else
                AllowJump = false;
            
            if(Handler.InputController.IsClicking())
                Handler.Jump();
                
        }

        private bool HasFinishedRotation() => Math.Abs(Handler.transform.rotation.eulerAngles.x - 25.0f) < 5.0f;

        private void ResetGroundPosition()
        {
            Handler.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            AllowJump = true;
        }

    }
