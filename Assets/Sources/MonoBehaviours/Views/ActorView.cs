using UnityEngine;
using Photon.Pun;


namespace RustedGames
{
	public sealed class ActorView : MonoBehaviour
	{
		[SerializeField] private Canvas actorHUDCanvas;
		[SerializeField] private PhotonView photonView;

        private void Awake()
        {
            actorHUDCanvas.gameObject.SetActive(!photonView.IsMine);
            actorHUDCanvas.GetComponent<ActorHUDController>().SetPlayerName(photonView.IsMine ? PhotonNetwork.NickName :
                photonView.Owner.NickName);
        }
    }
}