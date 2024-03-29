﻿using System.Collections.Generic;
using Entitas;

using UnityEngine;
using DG.Tweening;

namespace RustedGames.Launcher
{
	/// <summary>
	/// System that switches the Connection UI according to the state of the game.
	/// </summary>
	public class ConnectionUISystem : ReactiveSystem<NetworkEntity> 
	{
		private readonly NetworkContext _networkContext;
		private readonly CanvasGroup _loadingScreen;

		public ConnectionUISystem (Contexts contexts, CanvasGroup loadingScreen) : base(contexts.network)
		{
			_networkContext = contexts.network;
			_loadingScreen = loadingScreen;
		}
			
		protected override ICollector<NetworkEntity> GetTrigger(IContext<NetworkEntity> context) 
		{
			return context.CreateCollector(NetworkMatcher.PendingConnection.AddedOrRemoved());
		}
			
		protected override bool Filter(NetworkEntity entity) 
		{			
			return true;
		}

		protected override void Execute(List<NetworkEntity> entities) 
		{
			if (_loadingScreen == null) return;

			if (_networkContext.isPendingConnection)
			{
				_loadingScreen.gameObject.SetActive(true);
				_loadingScreen.DOFade(1f, 1f).SetEase(Ease.OutExpo);
			}
		}
	}
}