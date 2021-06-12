using System;
using UnityEngine;

namespace RustedGames
{
	[CreateAssetMenu(fileName = "Assets/_LH/Data/Settings/NewGameSettings", menuName = "LittleHunter/Data/Settings/Game", order = 0)]
	public class GameSettingsData : ScriptableObject
	{
		[Header("Game Settings")]
		public string GameVersion;
		public int BuildNumber;

		[Header("Multiplayer Settings"), Space(2f)]
		public NetworkPreset NetworkConfig;

		[Serializable]
		public class NetworkPreset
		{
			public int MaxNumberOfPlayers;
			public string RoomSceneName;
		}
	}
}