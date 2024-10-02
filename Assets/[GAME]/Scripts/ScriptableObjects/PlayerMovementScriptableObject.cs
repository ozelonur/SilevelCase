using _GAME_.Scripts.Models;
using UnityEngine;

namespace _GAME_.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Movement Settings", menuName = "Silevel Games/Player/Player Movement Settings", order = 1)]
    public class PlayerMovementScriptableObject : ScriptableObject
    {
        public PlayerMovementData data;
    }
}