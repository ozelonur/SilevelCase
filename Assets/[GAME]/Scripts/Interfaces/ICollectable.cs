using _GAME_.Scripts.Models;
using _GAME_.Scripts.ScriptableObjects;

namespace _GAME_.Scripts.Interfaces
{
    public interface ICollectable
    {
        public CollectableScriptableObject collectableData { get; set; }

        void Collect(params object[] arguments);
    }
}