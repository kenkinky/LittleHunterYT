using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// Flag whether the connection was successful!
/// </summary>
[Network, Unique]
public sealed class ConnectionSuccessfulComponent : IComponent {}
