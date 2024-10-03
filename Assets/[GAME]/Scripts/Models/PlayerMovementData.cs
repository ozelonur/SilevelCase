using System;
using UnityEngine;

namespace _GAME_.Scripts.Models
{
    [Serializable]
    public struct PlayerMovementData
    {
        [Header("Player Movement Settings")] [Range(1, 10)]
        public float forwardSpeed;
        public float swipeSensitivity;
        public float xClampRange;

    }
}