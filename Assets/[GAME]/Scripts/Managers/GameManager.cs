using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.Manager;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class GameManager : Manager<GameManager>
    {
        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameCompleted;
        
        protected override void Awake()
        {
            base.Awake();
            Application.targetFrameRate = 60;
        }

        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.OnGameStart, OnGameStart);
                Register(CustomEvents.OnGameComplete, OnGameComplete);
            }

            else
            {
                Unregister(CustomEvents.OnGameStart, OnGameStart);
                Unregister(CustomEvents.OnGameComplete, OnGameComplete);
            }
        }

        private void OnGameComplete(object[] arguments)
        {
            isGameCompleted = (bool)arguments[0];
        }

        private void OnGameStart(object[] arguments)
        {
            isGameStarted = (bool)arguments[0];
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}