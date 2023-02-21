using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatSystem
{
	public class CharacterData : MonoBehaviour
	{
		[SerializeField] private BaseCharacterStats baseStats;

		public Dictionary<string, Stat> Stats { get; private set;}

		private void Awake()
		{
			InitializeStats();
		}

		private void InitializeStats()
		{
			foreach(Stat stat in baseStats.CharacterStats)
			{
				Stats[stat.Name] = stat.DeepCopy();
			}
		}
	}
}