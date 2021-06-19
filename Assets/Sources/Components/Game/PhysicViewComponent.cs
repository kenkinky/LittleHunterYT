using Entitas;
using UnityEngine;

/// <summary>
/// Stores the Rigidbody associated with the entity.
/// </summary>
[Game]
public sealed class PhysicViewComponent : IComponent 
{
	public Rigidbody value;
}
