using _GAME_.Scripts.Interfaces;
using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Player
{
    public class PlayerCollisionActor : Actor
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }

            if (other.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect();
            }

            if (other.TryGetComponent(out IObstacle obstacle))
            {
                obstacle.Hit();
            }
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}