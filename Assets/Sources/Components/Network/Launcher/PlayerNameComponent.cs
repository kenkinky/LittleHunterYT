using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// Stores the Player Name of the active player
/// </summary>
[Game, Unique]
public sealed class PlayerNameComponent : IComponent 
{
	public string value;
}
