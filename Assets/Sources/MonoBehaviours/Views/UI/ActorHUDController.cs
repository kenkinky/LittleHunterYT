using UnityEngine;

namespace RustedGames
{
	public sealed class ActorHUDController : MonoBehaviour
	{
		[SerializeField] private TMPro.TextMeshProUGUI actorTitleText;
		[SerializeField] private TMPro.TextMeshProUGUI actorNameText;
		[SerializeField] private TMPro.TextMeshProUGUI actorDamageText;

		public void SetPlayerName(string text)
        {
			actorNameText.text = text;
        }

		public void SetPlayerTitle(string text)
		{
			actorTitleText.text = text;
		}

		public void SetPlayerDamage(string text)
		{
			actorDamageText.text = text;
		}

	}
}