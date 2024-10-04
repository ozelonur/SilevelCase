using _GAME_.Scripts.Models;
using UnityEngine;

namespace _GAME_.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Coin Settings", menuName = "Silevel Games/Collectable/Coin Settings", order = 1)]
    public class CollectableScriptableObject : ScriptableObject
    {
        public CollectableData data;
    }
}