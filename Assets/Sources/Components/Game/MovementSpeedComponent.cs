using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// The Movement Speed of the Local Player
/// </summary>
[Game]
public sealed class MovementSpeedComponent : IComponent 
{
    public float Value;
}
