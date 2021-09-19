using Entitas;
using UnityEngine;

namespace RustedGames
{
	public class UpdateMoveDirectionSystem : IExecuteSystem  
	{
        private InputContext _inputContext;
        private Transform cameraTransform;
        private readonly IGroup<GameEntity> entities;

        public UpdateMoveDirectionSystem(Contexts contexts, Transform cameraTransform)
		{
			_inputContext = contexts.input;
            this.cameraTransform = cameraTransform;
            entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveDirection));
		}
		

		public void Execute() 
		{
            foreach (GameEntity e in entities)
            {
                if (e.isLocalPlayer)
                {
                    Vector2 axesValue = _inputContext.moveInput.value;

                    Vector3 moveDirection = cameraTransform.forward * axesValue.y;
                    moveDirection = moveDirection + cameraTransform.right * axesValue.x;
                    moveDirection.Normalize();
                    moveDirection.y = 0;
                    moveDirection = moveDirection * e.movementSpeed.Value;
                    e.ReplaceMoveDirection(moveDirection);
                    e.isMoving = moveDirection != Vector3.zero;
                }
                else
                {
                    // AI driven
                }
            }
			
		}
	}
}