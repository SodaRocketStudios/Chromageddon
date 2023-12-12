using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;
using SRS.AI;

namespace SRS.EnemyManagement
{
	
	[CreateAssetMenu(fileName = "EnemyData", menuName = "Chromageddon/EnemyData", order = 0)]
	public class EnemyData : ScriptableObject
	{
		// store all data needed to spawn an enemy.
		public List<StatModifier> InitialStats;
		public Sprite Sprite;
		public State initialState;
	}
}