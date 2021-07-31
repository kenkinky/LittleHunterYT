using UnityEngine;
using Entitas;
using System.Collections.Generic;
using Photon.Pun;

namespace RustedGames
{
	public sealed class SandboxSystem : MonoBehaviourPunCallbacks
	{
		[SerializeField] private List<Transform> SpawnPoints;
        [SerializeField] private Transform CameraRoot;
        [SerializeField] private Transform CameraPivot;

		private Systems _systems;
		private Contexts _contexts;

        private Systems _physicSystems;
        private Systems _lateFixedUpdateSystems;

		private void Awake()
		{
			_contexts = Contexts.sharedInstance;
			_systems = new Feature("Game Systems");
            _physicSystems = new Feature("Physics Systems");
            _lateFixedUpdateSystems = new Feature("Late Systems");

			_systems.Add(new CreateSpawnPointSystem(_contexts, SpawnPoints));
			_systems.Add(new CreateLocalPlayerSystem(_contexts));

            _physicSystems.Add(new MovePlayerSystem(_contexts));
            _physicSystems.Add(new RotatePlayerSystem(_contexts));
            _lateFixedUpdateSystems.Add(new CameraFollowTargetSystem(_contexts, CameraRoot));
            _lateFixedUpdateSystems.Add(new CameraRotateSystem(_contexts, CameraRoot, CameraPivot));
        }

		private void Start()
		{
			_contexts.network.isPendingConnection = false;
			_systems.Initialize();
            _physicSystems.Initialize();
            _lateFixedUpdateSystems.Initialize();

        }

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

        private void FixedUpdate()
        {
            _physicSystems.Execute();
            _lateFixedUpdateSystems.Execute();
            _physicSystems.Cleanup();
            _lateFixedUpdateSystems.Cleanup();
        }
    }
}