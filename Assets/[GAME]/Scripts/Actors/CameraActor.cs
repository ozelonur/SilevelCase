using _GAME_.Scripts.GlobalVariables;
using Cinemachine;
using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors
{
    public class CameraActor : Actor
    {
        [SerializeField] private CinemachineVirtualCamera mainVCam;


        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.SetCameraFollowTransform, GetCameraFollowTransform);
            }

            else
            {
                Unregister(CustomEvents.SetCameraFollowTransform, GetCameraFollowTransform);
            }
        }

        private void GetCameraFollowTransform(object[] arguments)
        {
            mainVCam.m_Follow = (Transform)arguments[0];
        }

        public override void ResetActor()
        {
            
        }

        public override void InitializeActor()
        {
            
        }
    }
}