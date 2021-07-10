using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// This is the Rotation Speed of the Local Player
/// </summary>
[Game]
public sealed class RotationSpeedComponent : IComponent 
{
    public float Value;
}
