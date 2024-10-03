using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.EventSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GAME_.Scripts.Actors.Player
{
    public class PlayerInputActor : Actor
    {
        private PlayerInputActions _playerInputActions;

        private Vector2 _mouseDelta;

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
        }


        protected override void OnEnable()
        {
            base.OnEnable();
            _playerInputActions.Player.Delta.performed += OnTouchPerformed;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _playerInputActions.Player.Delta.performed -= OnTouchPerformed;
            
        }

        private void OnTouchPerformed(InputAction.CallbackContext context)
        {
            Vector2 touchPosition = context.ReadValue<Vector2>();
            Push(CustomEvents.SetMouseDelta, touchPosition);
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
        }
        
        
    }
}