using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Platform
{
    public class SpawnTriggerActor : Actor, IInteractable
    {
        private Transform _platformEndTransform;

        public void InitTransforms(Transform platformEndTransform)
        {
            _platformEndTransform = platformEndTransform;
        }

        public void Interact(params object[] arguments)
        {
            Push(CustomEvents.SpawnPlatform, _platformEndTransform);
        }

        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
        }
    }
}