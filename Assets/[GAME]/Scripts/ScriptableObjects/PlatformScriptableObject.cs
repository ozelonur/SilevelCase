using _GAME_.Scripts.Models;
using UnityEngine;

namespace _GAME_.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Platform Settings", menuName = "Silevel Games/Platform/Platform Settings", order = 1)]
    public class PlatformScriptableObject : ScriptableObject
    {
        public PlatformData data;
    }
}