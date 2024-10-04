using System.Collections.Generic;
using _GAME_.Scripts.Actors.Environment;
using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.EventSystem;
using SoundlightInteractive.Pooling;
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

        private List<EnvironmentActor> _currentEnvironments = new();

        private void Awake()
        {
            _scalePivot = transform.GetChild(0);
            spawnTriggerActor.InitTransforms(platformEndTransform);
            AlignTiling();
        }

        public override void ResetActor()
        {
            foreach (EnvironmentActor currentEnvironment in _currentEnvironments)
            {
                PoolManager.Instance.ReleaseToPool(PoolType.Environment, currentEnvironment);
            }
            
            _currentEnvironments.Clear();
        }

        public override void InitializeActor()
        {
            int requiredEnvironmentCount = Mathf.RoundToInt(_scalePivot.localScale.z / 10);


            for (int i = 0; i < requiredEnvironmentCount; i++)
            {
                Vector3 pos = Vector3.zero;
                pos.z = i * 10;
                EnvironmentActor environmentActor =
                    PoolManager.Instance.SpawnFromPool<EnvironmentActor>(PoolType.Environment, pos,
                        Quaternion.identity);

                environmentActor.transform.parent = transform;
                environmentActor.transform.localPosition = pos;
                
                _currentEnvironments.Add(environmentActor);
            }
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