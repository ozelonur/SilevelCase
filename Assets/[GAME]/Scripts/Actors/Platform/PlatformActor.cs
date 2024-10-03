using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Platform
{
    public class PlatformActor : Actor
    {
        [SerializeField] private Transform platformEndTransform;
        [SerializeField] private SpawnTriggerActor spawnTriggerActor;

        private void Awake()
        {
            spawnTriggerActor.InitTransforms(platformEndTransform);
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
        }
        
    }
}