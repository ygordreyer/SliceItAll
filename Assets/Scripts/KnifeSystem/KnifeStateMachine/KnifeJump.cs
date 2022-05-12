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
        Handler.Rigidbody.isKinematic = false;
        UnlockXRotation();
        Jump();
        Rotate();
    }

    private void Jump()
    {
        Handler.Rigidbody.velocity = Vector3.zero;
        Handler.Rigidbody.angularVelocity = Vector3.zero; 
        Handler.Rigidbody.AddForce(GameManager.Instance.Settings.jumpForce);
    }

    private void UnlockXRotation() => Handler.Rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

    private void Rotate() => Handler.Rigidbody.AddTorque(Handler.transform.right * 10f, ForceMode.VelocityChange);

}
