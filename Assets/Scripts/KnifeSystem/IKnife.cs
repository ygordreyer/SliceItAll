using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnife : IStateMachineHandler, IKnifeComponents
{
    bool IsFalling { get; }
    bool IsIdle { get; }
    bool IsJumping { get; }
    void Jump();
    void Fall();
    void Idle();
}
