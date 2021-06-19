using UnityEngine;
using Photon.Pun;

namespace RustedGames
{
	/// <summary>
	/// Utility script that deactive the rigidbody when it's not owned.
	/// </summary>
	public sealed class RigidbodyDeactivor : MonoBehaviour
	{
		private Rigidbody rigidbody;
		private PhotonView photonView;

		private void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
			photonView = GetComponent<PhotonView>();
		}

		private void Start()
		{
			if (!photonView.IsMine)
			{
				rigidbody.isKinematic = true;
			}
		}
	}
}