using SoundlightInteractive.Manager;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class MoneyManager : Manager<MoneyManager>
    {
        public int Money
        {
            get => PlayerPrefs.GetInt("Money");
            set => PlayerPrefs.SetInt("Money", value);
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}