using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Knife : MonoBehaviour, IKnife
    {
        #region Private Variables
        
        private Rigidbody MyRigidbody;
        private KnifeStateMachine StateMachine { get; set; }

        #endregion

        #region Public Variables
        
        public string Name => "Knife";
        public bool IsFalling => StateMachine.IsCurrent<KnifeFalling>();
        public bool IsIdle => StateMachine.IsCurrent<KnifeIdle>();
        public bool IsJumping => StateMachine.IsCurrent<KnifeIdle>();
        public Camera MainCamera => Camera.main;
        public Rigidbody Rigidbody => MyRigidbody;
        public KnifeInputController InputController { get; set; }

        #endregion

        #region Unity CallBacks
        
        private void Awake()
        {
            StateMachine = new KnifeStateMachine(MainCamera, this);
            InputController = new KnifeInputController();
            MyRigidbody = GetComponent<Rigidbody>();
            StateMachine.Fall();
            
            var cm = MyRigidbody.centerOfMass;
            MyRigidbody.centerOfMass = cm + GameManager.Instance.Settings.centerOfMassOffset;

        }

        private void Update() => StateMachine?.Update();

        private void OnCollisionEnter(Collision collision) => CheckGround(collision);

        private void OnTriggerEnter(Collider other) => CheckDeath(other);
        
        #endregion

        #region Functions

        private void CheckGround(Collision collision)
        {
            if (!IsFalling) return;

            if (collision.collider.CompareTag(GameManager.Instance.Settings.GroundTag))
                StateMachine.Idle();
        }
        
        private void CheckDeath(Collider other)
        {
            if (other.CompareTag(GameManager.Instance.Settings.KillBoxTag))
                SceneManager.LoadScene(0);
        }

        #endregion


        #region FSM

        public void Fall() => StateMachine.Fall();
        
        public void Idle() => StateMachine.Idle();
        
        public void Jump() => StateMachine.Jump();

        #endregion

    }
}