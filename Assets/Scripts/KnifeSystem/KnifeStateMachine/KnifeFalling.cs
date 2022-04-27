
    using System;
    using UnityEngine;

    public class KnifeFalling : KnifeBaseState
    {
        public KnifeFalling(IKnife handler, BaseStateMachine stateMachine) : base(handler, stateMachine)
        {
        }

        private bool AllowJump = false;
        
        public override void OnUpdate()
        {
            if (!StateMachine.IsCurrent<KnifeIdle>() &&
                Math.Abs(Handler.transform.rotation.eulerAngles.x - 25.0f) < 5.0f)
            {
                Handler.Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                AllowJump = true;
            }
            else
                AllowJump = false;
            
            if(AllowJump && (Input.GetKeyDown("space") || Input.GetTouch(0).phase == TouchPhase.Began))
                Handler.Jump();
                
        }

    }
