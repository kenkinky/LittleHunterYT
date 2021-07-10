using Entitas;
using UnityEngine;

namespace RustedGames
{
    /// <summary>
    /// This system rotates the local Player according to the move inputs.
    /// because we're using a rigidbody, this system has to run on FixedUpdate
    /// </summary>
	public class RotatePlayerSystem : IExecuteSystem  
	{
		private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private Transform cameraObject;
		
		public RotatePlayerSystem(Contexts contexts)
		{
            _gameContext = contexts.game;
            _inputContext = contexts.input;
            cameraObject = Camera.main.transform;
		}
		

		public void Execute() 
		{
			if (_gameContext.isLocalPlayer)
            {
                GameEntity localPlayer = _gameContext.localPlayerEntity;
                Vector2 axesValue = _inputContext.moveInput.value;

                Vector3 targetDirection = cameraObject.forward * axesValue.y;
                targetDirection = targetDirection + cameraObject.right * axesValue.x;
                targetDirection.Normalize();
                targetDirection.y = 0;

                if (targetDirection == Vector3.zero)
                {
                    targetDirection = localPlayer.gameView.transform.forward;
                }

                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                Quaternion playerRotation = Quaternion.Slerp(localPlayer.gameView.transform.rotation,
                    targetRotation, localPlayer.rotationSpeed.Value * Time.fixedDeltaTime);

                localPlayer.gameView.transform.rotation = playerRotation;

            }
		}
	}
}