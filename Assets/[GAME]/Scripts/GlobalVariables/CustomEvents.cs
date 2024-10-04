namespace _GAME_.Scripts.GlobalVariables
{
    public static class CustomEvents
    {
        // Game Status
        public const string OnGameStart = nameof(OnGameStart);
        public const string OnGameComplete = nameof(OnGameComplete);
        
        // Player Movement
        public const string SetMouseDelta = nameof(SetMouseDelta);
        public const string SetMoveStatus = nameof(SetMoveStatus);
        
        // Player Interactions
        public const string Die = nameof(Die);
        
        // Camera
        public const string SetCameraFollowTransform = nameof(SetCameraFollowTransform);
        
        // Spawn Logic
        public const string SpawnPlatform = nameof(SpawnPlatform);
        
        // UI
        public const string UpgradeMoneyText = nameof(UpgradeMoneyText);
    }
}