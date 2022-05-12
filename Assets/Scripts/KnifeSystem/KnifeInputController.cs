using UnityEngine;

namespace DefaultNamespace
{
    public class KnifeInputController : IKnifeInputController
    {
        public bool IsClicking() => Input.GetKeyDown("space");
    }
}