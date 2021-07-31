using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// How fast the camera rotates
/// </summary>
[Game, Unique]
public sealed class CameraPivotSpeedComponent : IComponent 
{
    public float value;
}
