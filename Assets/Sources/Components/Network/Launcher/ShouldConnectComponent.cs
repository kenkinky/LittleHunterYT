﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

/// <summary>
/// Should we try to connect to the game server?
/// </summary>
[Network, Unique]
public sealed class ShouldConnectComponent : IComponent { }
