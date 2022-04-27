using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Knife : MonoBehaviour, IKnife
    {
        private Transform MyTransform;
        private Collider MyCollider;
        private Rigidbody MyRigidbody;
        
        public string Name => "Knife";
        public bool IsFalling => StateMachine.IsCurrent<KnifeFalling>();
        public bool IsIdle => StateMachine.IsCurrent<KnifeIdle>();
        public bool IsJumping => StateMachine.IsCurrent<KnifeIdle>();
        public Camera MainCamera => Camera.main;
        public Collider Collider => MyCollider;
        public Rigidbody Rigidbody => MyRigidbody;
        public MonoBehaviour MonoBehavior => this;

        private KnifeStateMachine StateMachine { get; set; }

        private void Awake()
        {
            StateMachine = new KnifeStateMachine(MainCamera, this);
            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            StateMachine.Fall();
            
            var cm = MyRigidbody.centerOfMass;
            MyRigidbody.centerOfMass = cm + GameManager.Instance.centerOfMassOffset;

        }

        private void Update()
        {
            StateMachine?.Update();
            
            //Remove comment for easier testing of center of mass
            /*
            MyRigidbody.ResetCenterOfMass();
            var cm = MyRigidbody.centerOfMass;
            MyRigidbody.centerOfMass = cm + GameManager.Instance.centerOfMassOffset;
            */

        }
        
        void OnCollisionEnter(Collision collision)
        {
            if (!IsFalling) return;

            if (collision.collider.CompareTag(GameManager.GroundTag))
                StateMachine.Idle();
        }
        
        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag(GameManager.KillBoxTag))
            {
                SceneManager.LoadScene(0);
            }
            
        }


        public void Fall() => StateMachine.Fall();
        
        public void Idle() => StateMachine.Idle();
        
        public void Jump() => StateMachine.Jump();

    }
}