using System.Collections.Generic;
using _GAME_.Scripts.Actors.Platform;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.ScriptableObjects;
using SoundlightInteractive.Manager;
using SoundlightInteractive.Pooling;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class PlatformManager : Manager<PlatformManager>
    {
        [SerializeField] private PlatformGenerateType generateType;
        [SerializeField] private PlatformScriptableObject[] platformDataArray;

        private List<PlatformActor> _activePlatforms = new();

        private int _activePlatformIndex;

        private void Start()
        {
            for (int i = 0; i < platformDataArray.Length; i++)
            {
                PoolManager.Instance.CreatePool(PoolType.Platform + i, platformDataArray[i].data.platformPrefab, 10);
            }

            for (int i = 0; i < 10; i++)
            {
                Vector3 pos = i == 0 ? Vector3.zero : platformDataArray[i % platformDataArray.Length].data.platformPrefab.GetEndTransform().position;
                PlatformActor platform = PoolManager.Instance.SpawnFromPool<PlatformActor>(
                    PoolType.Platform + (i % platformDataArray.Length),
                    pos,
                    Quaternion.identity);

                platform.transform.position = i == 0 ? Vector3.zero : _activePlatforms[^1].GetEndTransform().position;

                platform.poolIndex = i % platformDataArray.Length;

                _activePlatforms.Add(platform);

                if (i < 2)
                {
                    platform.SetSpawnTriggerColliderTriggerStatus(false);
                }
            }
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
            int generateIndex;

            if (generateType == PlatformGenerateType.Progressive)
            {
                generateIndex = _activePlatformIndex % platformDataArray.Length;
            }
            else
            {
                generateIndex = Random.Range(0, platformDataArray.Length);
            }
            
            
            PlatformActor platform =
                PoolManager.Instance.SpawnFromPool<PlatformActor>(
                    PoolType.Platform + generateIndex, _activePlatforms[^1].GetEndTransform().position,
                    Quaternion.identity);

            platform.poolIndex = generateIndex;

            _activePlatformIndex++;

            _activePlatforms.Add(platform);
            PoolManager.Instance.ReleaseToPool(PoolType.Platform + _activePlatforms[0].poolIndex, _activePlatforms[0]);
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