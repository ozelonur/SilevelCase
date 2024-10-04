using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.Manager;
using UnityEngine;

namespace _GAME_.Scripts.Managers
{
    public class MoneyManager : Manager<MoneyManager>
    {
        public int Money
        {
            get => PlayerPrefs.GetInt("Money");
            set
            {
                PlayerPrefs.SetInt("Money", value);
                Push(CustomEvents.UpgradeMoneyText);
            } 
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}