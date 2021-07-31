using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// How fast the camera follows the local player
/// </summary>
[Game, Unique]
public sealed class CameraLookSpeedComponent : IComponent 
{
    public float value;
}
