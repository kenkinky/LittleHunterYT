using UnityEngine;

namespace RustedGames
{
	public sealed class PreBoostrap : MonoBehaviour
	{
		[SerializeField]
		private GameObject splashScene;

		private void Awake()
		{
			BootstrapStart();
		}

		private void BootstrapStart()
		{
			splashScene.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}