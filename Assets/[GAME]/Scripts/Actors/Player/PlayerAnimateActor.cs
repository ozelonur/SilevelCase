using _GAME_.Scripts.GlobalVariables;
using JetBrains.Annotations;
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
                Register(CustomEvents.Die, DieEvent);
            }

            else
            {
                Unregister(CustomEvents.OnGameStart, OnGameStart);
                Unregister(CustomEvents.Die, DieEvent);
            }
        }

        private void DieEvent(object[] arguments)
        {
            Die();
        }

        private void OnGameStart(object[] arguments)
        {
            Run(true);
        }

        private void Run(bool status)
        {
            _animator.SetBool(RunKey, status);
        }

        private void Die()
        {
            _animator.SetTrigger(DieKey);
        }
        
        [UsedImplicitly]
        private void DieCompleted()
        {
            Push(CustomEvents.OnGameComplete, false);
        }

        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
        }
    }
}