using _GAME_.Scripts.Actors.Environment;
using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.EventSystem;
using SoundlightInteractive.Pooling;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class EnvironmentManager : Actor
    {
        [SerializeField] private EnvironmentActor environmentPrefab;
        private void Start()
        {
            PoolManager.Instance.CreatePool(PoolType.Environment, environmentPrefab, 250);
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}