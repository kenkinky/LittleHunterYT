﻿using RustedGames;

public sealed class GameSystems : Feature 
{
	public GameSystems(Contexts contexts)
	{
		//Add(new CreateEntitySystem(contexts));
		Add(new EmitInputSystem(contexts, new UnityInputServiceImplementation()));
	}
}
