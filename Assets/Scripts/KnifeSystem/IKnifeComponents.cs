using UnityEngine;

public interface IKnifeComponents
{
    Camera MainCamera { get; }
    Collider Collider { get; }
    Rigidbody Rigidbody { get; }
    MonoBehaviour MonoBehavior { get; }
    GameObject gameObject { get; }
    Transform transform { get; }
}
