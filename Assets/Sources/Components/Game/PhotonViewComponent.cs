using Entitas;

/// <summary>
/// Stores the PhotonView associated with the entity.
/// </summary>
[Game]
public sealed class PhotonViewComponent : IComponent 
{
	public Photon.Pun.PhotonView value;
}
