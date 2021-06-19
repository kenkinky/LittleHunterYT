using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Photon.Pun;

namespace RustedGames
{
	public sealed class SandboxSystem : MonoBehaviourPunCallbacks
	{
		[SerializeField] private List<Transform> SpawnPoints;

		private Systems _systems;
		private Contexts _contexts;

		private void Awake()
		{
			_contexts = Contexts.sharedInstance;
			_systems = new Feature("Game Systems");
			_systems.Add(new CreateSpawnPointSystem(_contexts, SpawnPoints));
			_systems.Add(new CreateLocalPlayerSystem(_contexts));
		}

		private void Start()
		{
			_contexts.network.isPendingConnection = false;
			_systems.Initialize();
		}

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}
	}
}