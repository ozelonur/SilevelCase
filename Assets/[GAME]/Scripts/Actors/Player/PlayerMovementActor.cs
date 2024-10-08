using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Managers;
using _GAME_.Scripts.Models;
using _GAME_.Scripts.ScriptableObjects;
using JetBrains.Annotations;
using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementActor : Actor
    {
        [SerializeField] private PlayerMovementScriptableObject playerMovementData;

        private GameManager _gameManager;

        private Rigidbody _rigidbody;

        private Vector2 _mouseDelta;

        private float _forwardSpeed;
        private float _swipeSensitivity;
        private float _xClampRange;

        private bool _canMove;

        private void Awake()
        {
            PlayerMovementData movementData = playerMovementData.data;

            _forwardSpeed = movementData.forwardSpeed;
            _swipeSensitivity = movementData.swipeSensitivity;
            _xClampRange = movementData.xClampRange;

            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        private void FixedUpdate()
        {
            if (_gameManager.isGameCompleted || !_gameManager.isGameStarted)
            {
                return;
            }

            if (!_canMove)
            {
                return;
            }

            MoveForward();
            MoveHorizontal();
        }

        private void MoveForward()
        {
            Vector3 forwardMove = Vector3.forward * (_forwardSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(_rigidbody.position + forwardMove);
        }

        private void MoveHorizontal()
        {
            float horizontalMove = _mouseDelta.x * _swipeSensitivity * Time.fixedDeltaTime;
            Vector3 horizontalMovement = Vector3.right * horizontalMove;
            Vector3 newPosition = _rigidbody.position + horizontalMovement;

            float clampedX = Mathf.Clamp(newPosition.x, -_xClampRange, _xClampRange);
            newPosition = new Vector3(clampedX, newPosition.y, newPosition.z);

            _rigidbody.MovePosition(newPosition);

            _mouseDelta = Vector2.zero;
        }

        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.SetMouseDelta, GetMouseDelta);
                Register(CustomEvents.SetMoveStatus, GetMoveStatus);
                Register(CustomEvents.OnGameStart, OnGameStart);
            }
            else
            {
                Unregister(CustomEvents.SetMouseDelta, GetMouseDelta);
                Unregister(CustomEvents.SetMoveStatus, GetMoveStatus);
                Unregister(CustomEvents.OnGameStart, OnGameStart);
            }
        }

        private void OnGameStart(object[] arguments)
        {
            _canMove = true;
        }

        private void GetMoveStatus(object[] arguments)
        {
            _canMove = (bool)arguments[0];
        }

        private void GetMouseDelta(object[] arguments)
        {
            _mouseDelta = (Vector2)arguments[0];
        }

        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
        }
    }
}