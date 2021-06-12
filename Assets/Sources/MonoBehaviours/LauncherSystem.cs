using System;

using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Entitas;

namespace RustedGames.Launcher
{
	public sealed class LauncherSystem : MonoBehaviourPunCallbacks
	{
		[SerializeField] private TMP_InputField PlayerNameField;
		[SerializeField] private Button StartConnectButton;
		[SerializeField] private CanvasGroup loadingScreen;

		public event Action onConnectedToMaster;
		public event Action<object[]> onPhotonRandomJoinFailed;
		public event Action onJoinedRoom;

		private Systems _systems;
		private Systems _serverSystems;
		private Contexts _contexts;
		private bool serverSystemInitialized = false;

		private void Awake()
		{
			// #Critical
			// this makes sure we can use PhotonNetwork.LoadLevel() on 
			//the master client and all clients in the same room sync their level automatically
			PhotonNetwork.AutomaticallySyncScene = true;

			_contexts = Contexts.sharedInstance;
			_systems = new Feature("Launcher Systems");
			_serverSystems = new Feature("Server Systems");

			_systems.Add(new InitializePlayerNameSystem(_contexts, PlayerNameField));
			_systems.Add(new InitializeStartButtonSystem(_contexts, StartConnectButton));
			_systems.Add(new ConnectionSystem(_contexts, this));
			_systems.Add(new ConnectionUISystem(_contexts, loadingScreen));

			// todo: serversystems
			_serverSystems.Add(new LoadingLobbySystem(_contexts));
		}

		private void Start()
		{
			_systems.Initialize();
		}

		private void Update()
		{
			if (PhotonNetwork.IsMasterClient)
			{
				if (!serverSystemInitialized)
				{
					serverSystemInitialized = true;
					_serverSystems.Initialize();
				}

				_serverSystems.Execute();
				_serverSystems.Cleanup();
			}

			_systems.Execute();
			_systems.Cleanup();
		}

		#region MonoBehaviourPunCallbacks Callbacks

		public override void OnConnectedToMaster()
		{
			onConnectedToMaster?.Invoke();
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
			var codeAndMsg = new object[] { returnCode, message };

			onPhotonRandomJoinFailed?.Invoke(codeAndMsg);
		}

		public override void OnJoinedRoom()
		{
			onJoinedRoom?.Invoke();
		}
		#endregion
	}
}