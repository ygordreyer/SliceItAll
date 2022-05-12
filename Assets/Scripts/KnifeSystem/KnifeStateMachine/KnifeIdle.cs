    

public class KnifeIdle : KnifeBaseState
{
    public KnifeIdle(IKnife handler, BaseStateMachine stateMachine) : base(handler, stateMachine) { }

    public override void OnEnterState()
    {
        Handler.Rigidbody.isKinematic = true;
    }

    public override void OnUpdate()
    {
        if(Handler.InputController.IsClicking()) 
            Handler.Jump();
    }
}
