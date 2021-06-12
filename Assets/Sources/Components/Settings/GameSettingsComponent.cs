using Entitas;
using Entitas.CodeGeneration.Attributes;
using RustedGames;

[Settings, Unique]
public sealed class GameSettingsComponent : IComponent 
{
	public GameSettingsData value;
}
