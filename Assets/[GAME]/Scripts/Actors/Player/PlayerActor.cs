using _GAME_.Scripts.GlobalVariables;
using SoundlightInteractive.EventSystem;

namespace _GAME_.Scripts.Actors.Player
{
    public class PlayerActor : Actor
    {
        private void Start()
        {
            Push(CustomEvents.SetCameraFollowTransform, transform);
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}