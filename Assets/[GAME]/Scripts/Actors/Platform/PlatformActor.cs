using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Platform
{
    public class PlatformActor : Actor
    {
        [HideInInspector] public int poolIndex;
        
        [SerializeField] private Transform platformEndTransform;
        [SerializeField] private SpawnTriggerActor spawnTriggerActor;

        [SerializeField] private MeshRenderer platformRenderer;

        private Transform _scalePivot;

        private void Awake()
        {
            _scalePivot = transform.GetChild(0);
            spawnTriggerActor.InitTransforms(platformEndTransform);
            AlignTiling();
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

        private void AlignTiling()
        {
            float scaleY = _scalePivot.localScale.z;
            
            float tilingValue = scaleY / 5;

            platformRenderer.material.mainTextureScale = new Vector2(1, tilingValue);
        }
        
    }
}