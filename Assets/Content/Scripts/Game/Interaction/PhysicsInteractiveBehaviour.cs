using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Interaction
{
    public class PhysicsInteractiveBehaviour : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnInteractionStart;
        [SerializeField] private UnityEvent OnInteractionEnd;

        public  bool IsBeingInteracted                     { get; private set; }
        
        private void OnCollisionEnter2D(Collision2D other) => OnTriggerEnter2D(other.otherCollider);
        private void OnCollisionExit2D(Collision2D  other) => OnTriggerExit2D(other.otherCollider);
     

        private void OnTriggerEnter2D(Collider2D other)
        {
            IsBeingInteracted = true;
            OnInteractionStart?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IsBeingInteracted = false;
            OnInteractionEnd?.Invoke();
        }
    }
}