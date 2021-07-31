using Entitas;
using UnityEngine;

namespace RustedGames
{
	public class CameraFollowTargetSystem : IExecuteSystem, IInitializeSystem 
	{
		private readonly GameContext gameContext;
        private readonly Transform cameraTransform;
        private readonly SettingsContext settingsContext;

        private Transform targetTransform;
        private Vector3 cameraFollowVelocity = Vector3.zero;
		
		public CameraFollowTargetSystem(Contexts contexts, Transform theCameraTransform)
		{
			gameContext = contexts.game;
            cameraTransform = theCameraTransform;
            settingsContext = contexts.settings;
        }

        public void Initialize()
        {
            targetTransform = gameContext.localPlayerEntity.gameView.transform;
            gameContext.ReplaceCameraSmoothTime(settingsContext.gameSettings.value.
                CameraConfig.CameraSmoothTime);
        }
		

		public void Execute() 
		{
			if (gameContext.isLocalPlayer)
            {
                Vector3 targetPosition = Vector3.SmoothDamp(cameraTransform.position,
                    targetTransform.position, ref cameraFollowVelocity,
                    gameContext.cameraSmoothTime.value);

                cameraTransform.position = targetPosition;
            }
		}
	}
}