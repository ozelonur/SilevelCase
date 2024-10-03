using System.Collections.Generic;
using _GAME_.Scripts.Actors.Platform;
using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.Manager;
using SoundlightInteractive.Pooling;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class PlatformManager : Manager<PlatformManager>
    {
        [SerializeField] private PlatformActor platformPrefab;

        private List<PlatformActor> _activePlatforms = new();

        private int _activePlatformIndex;
        private void Start()
        {
            PoolManager.Instance.CreatePool(PoolType.Platform, platformPrefab, 150);
        }

        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.SpawnPlatform, SpawnPlatform);
            }

            else
            {
                Unregister(CustomEvents.SpawnPlatform, SpawnPlatform);
            }
        }

        private void SpawnPlatform(object[] arguments)
        {
            Transform target = (Transform)arguments[0];

            PlatformActor platform =
                PoolManager.Instance.SpawnFromPool<PlatformActor>(PoolType.Platform, target.position,
                    Quaternion.identity);
            
            _activePlatforms.Add(platform);

            if (_activePlatforms.Count <= 2) return;
            
            PoolManager.Instance.ReleaseToPool(PoolType.Platform, _activePlatforms[0]);
            _activePlatforms.RemoveAt(0);
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}