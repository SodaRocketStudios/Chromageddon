using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;
using SRS.AI;
using SRS.Combat;

namespace SRS.EnemyManagement
{
	
	[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/EnemyData", order = 0)]
	public class EnemyData : ScriptableObject
	{
		// store all data needed to spawn an enemy.
		public Weapon Weapon;
		public List<StatModifier> InitialStats;
		public List<EliteStatModifier> EliteModifiers;
		public int Price;
		public int MaxGroupSize;
		public bool IgnoreRecycleRequests;
		public Sprite Sprite;
		public Color Color;
		public State InitialState;
	}
}