using DefaultNamespace;
using UnityEngine;

public interface IKnifeComponents
{
    Rigidbody Rigidbody { get; }
    Transform transform { get; }
    KnifeInputController InputController { get; set; }
}
