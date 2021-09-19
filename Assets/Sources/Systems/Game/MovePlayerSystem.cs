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
        
		public MovePlayerSystem(Contexts contexts)
		{
            _gameContext = contexts.game;                
        }
		

		public void Execute() 
		{
			if (_gameContext.isLocalPlayer)
            {
                GameEntity localPlayer = _gameContext.localPlayerEntity;
                localPlayer.physicView.value.velocity = localPlayer.moveDirection.value;
            }
		}
	}
}