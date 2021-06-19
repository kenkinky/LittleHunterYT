using Entitas;
using UnityEngine;

/// <summary>
/// Stores the GameObject and the Transform associated with the entity.
/// </summary>
[Game]
public sealed class GameViewComponent : IComponent 
{
	public GameObject gameObject;
	public Transform transform;
}
