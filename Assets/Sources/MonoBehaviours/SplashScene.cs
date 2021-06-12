using System;
using System.Diagnostics;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace RustedGames
{
	public sealed class SplashScene : MonoBehaviour
	{
		[SerializeField] private GameObject bootstrapGameObject;
		[SerializeField] private Image logoImage;

		private Stopwatch _stopWatch = new Stopwatch();
		private bool isLoading;

		private void Awake()
		{
			logoImage.SetAlpha(0f);
		}

		private void Start()
		{
			logoImage.DOFade(1f, 1f).OnComplete(delegate
			{
				_stopWatch.Start();
				bootstrapGameObject.SetActive(true);
				_stopWatch.Stop();
				float delay = Mathf.Max(0f, Mathf.Min(2f - _stopWatch.ElapsedMilliseconds, 2f));
				logoImage.DOFade(0f, 1f).SetDelay(delay).OnComplete(OnLogoImageFadeOut);

			});
		}

		private void OnLogoImageFadeOut()
		{
			LoadSceneData();
		}

		private void LoadSceneData()
		{
			if (!isLoading)
			{
				isLoading = true;
				SceneManager.UnloadSceneAsync("Bootstrap");
			}
		}

	}
}