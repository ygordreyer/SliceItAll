using UnityEngine;

public class KnifeJump : KnifeBaseState
{
    public KnifeJump(IKnife handler, BaseStateMachine stateMachine) : base(handler, stateMachine)
    {
    }
    
    public override void OnUpdate()
    {
        if (Handler.Rigidbody.velocity.y < 0) Handler.Fall();
    }

    public override void OnEnterState()
    {
        Jump();
        Rotate();
    }

    void Jump()
    {
        Handler.Rigidbody.isKinematic = false;
        Handler.Rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        Handler.Rigidbody.velocity = Vector3.zero;
        Handler.Rigidbody.angularVelocity = Vector3.zero; 
        Vector3 velocity = new Vector3(-1,2,0);
        Handler.Rigidbody.AddForce(velocity);
    }

    void Rotate()
    {
        Handler.Rigidbody.AddTorque(Handler.transform.right * 10f, ForceMode.VelocityChange);
    }

}
