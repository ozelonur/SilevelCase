using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Platform
{
    public class PlatformActor : Actor
    {
        [HideInInspector] public int poolIndex;
        
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

        public void SetSpawnTriggerColliderTriggerStatus(bool status)
        {
            spawnTriggerActor.SetColliderStatus(status);
        }

        public Transform GetEndTransform()
        {
            return platformEndTransform;
        }
        
    }
}