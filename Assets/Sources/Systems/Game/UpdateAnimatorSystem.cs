using Entitas;

namespace RustedGames
{
	public class UpdateAnimatorSystem : IExecuteSystem  
	{
        private readonly IGroup<GameEntity> entities;
		
		public UpdateAnimatorSystem(Contexts contexts)
		{
            entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveDirection,
                GameMatcher.MovementSpeed, GameMatcher.AnimatorView));
		}	

		public void Execute() 
		{
			foreach(GameEntity e in entities)
            {
                e.animatorView.value.SetBool(Constants.AnimatorHash.IsMovingParam, e.isMoving);
            }
		}
	}
}