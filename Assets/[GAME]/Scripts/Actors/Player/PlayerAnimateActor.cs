using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimateActor : Actor
    {
        private Animator _animator;

        private static readonly int RunKey = Animator.StringToHash("Run");
        private static readonly int DieKey = Animator.StringToHash("Die");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.OnGameStart, OnGameStart);
            }

            else
            {
                Unregister(CustomEvents.OnGameStart, OnGameStart);
            }
        }

        private void OnGameStart(object[] arguments)
        {
            Run(true);
        }

        public void Run(bool status)
        {
            _animator.SetBool(RunKey, status);
        }

        public void Die()
        {
            _animator.SetTrigger(DieKey);
        }

        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
        }
    }
}