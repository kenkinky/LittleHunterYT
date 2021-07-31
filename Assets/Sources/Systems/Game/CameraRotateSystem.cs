using Entitas;
using UnityEngine;

namespace RustedGames
{
	public class CameraRotateSystem : IExecuteSystem, IInitializeSystem
	{
		private readonly GameContext gameContext;
        private readonly InputContext inputContext;
        private readonly SettingsContext settingsContext;
        private readonly Transform cameraTransform;
        private readonly Transform cameraPivotTransform;

        private float LookAngle;
        private float PivotAngle;
        private float MinimumPivotAngle;
        private float MaximumPivotAngle;
		
		public CameraRotateSystem(Contexts contexts, Transform theCameraTransform, Transform theCameraPivotTransform)
		{
			gameContext = contexts.game;
            inputContext = contexts.input;
            settingsContext = contexts.settings;
            cameraTransform = theCameraTransform;
            cameraPivotTransform = theCameraPivotTransform;
        }

        public void Initialize()
        {
            MinimumPivotAngle = settingsContext.gameSettings.value.CameraConfig.MinimumPivotAngle;
            MaximumPivotAngle = settingsContext.gameSettings.value.CameraConfig.MaximumPivotAngle;
            gameContext.ReplaceCameraLookSpeed(settingsContext.gameSettings.value.CameraConfig.CameraLookSpeed);
            gameContext.ReplaceCameraPivotSpeed(settingsContext.gameSettings.value.CameraConfig.CameraPivotSpeed);
        }
		

		public void Execute() 
		{
			if (gameContext.isLocalPlayer)
            {
                Vector2 axesValue = inputContext.lookInput.value;

                LookAngle = LookAngle + (axesValue.x * gameContext.cameraLookSpeed.value);
                PivotAngle = PivotAngle - (axesValue.y * gameContext.cameraPivotSpeed.value);
                PivotAngle = Mathf.Clamp(PivotAngle, MinimumPivotAngle, MaximumPivotAngle);

                Vector3 rotation = Vector2.zero;
                rotation.y = LookAngle;
                Quaternion targetRotation = Quaternion.Euler(rotation);
                cameraTransform.rotation = targetRotation;

                rotation = Vector3.zero;
                rotation.x = PivotAngle;

                targetRotation = Quaternion.Euler(rotation);
                cameraPivotTransform.localRotation = targetRotation;
            }
		}
	}
}