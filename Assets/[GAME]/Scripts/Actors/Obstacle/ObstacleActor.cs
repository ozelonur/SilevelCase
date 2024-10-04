using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Interfaces;
using SoundlightInteractive.EventSystem;

namespace _GAME_.Scripts.Actors.Obstacle
{
    public class ObstacleActor : Actor, IObstacle
    {
        public void Hit(params object[] arguments)
        {
            Push(CustomEvents.SetMoveStatus, false);
            Push(CustomEvents.Die);
        }
        
        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
            
        }

        
    }
}