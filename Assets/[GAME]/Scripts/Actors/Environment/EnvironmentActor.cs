using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Environment
{
    public class EnvironmentActor : Actor
    {
        [SerializeField] private GameObject[] environmentSets;

        private void Awake()
        {
            foreach (GameObject environmentSet in environmentSets)
            {
                environmentSet.SetActive(false);
            }
        }

        public override void ResetActor()
        {
            foreach (GameObject environmentSet in environmentSets)
            {
                environmentSet.SetActive(false);
            }
        }

        public override void InitializeActor()
        {
            int index = Random.Range(0, environmentSets.Length);
            
            environmentSets[index].SetActive(true);
        }
    }
}