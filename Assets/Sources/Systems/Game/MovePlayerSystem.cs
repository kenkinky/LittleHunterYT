using Entitas;
using UnityEngine;

namespace RustedGames
{
    /// <summary>
    /// The system moves the player according to the move inputs,
    /// becuase we're using a rigidbody, this system has to run in FixedUpdate
    /// </summary>
	public class MovePlayerSystem : IExecuteSystem  
	{
		private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private Transform cameraObject;
		
		public MovePlayerSystem(Contexts contexts)
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

                Vector3 moveDirection = cameraObject.forward * axesValue.y;
                moveDirection = moveDirection + cameraObject.right * axesValue.x;
                moveDirection.Normalize();
                moveDirection.y = 0;
                moveDirection = moveDirection * localPlayer.movementSpeed.Value;

                localPlayer.physicView.value.velocity = moveDirection;
            }
		}
	}
}