using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// How smooth the camera moves towards the local player
/// </summary>
[Game, Unique]
public sealed class CameraSmoothTimeComponent : IComponent 
{
    public float value;
}
