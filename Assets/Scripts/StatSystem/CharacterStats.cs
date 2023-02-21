using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatSystem
{
	public class CharacterStats : MonoBehaviour
	{
		[SerializeField] private BaseCharacterStats baseStats;

		private Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
		public float this[string key]
		{ 
			get
			{
				return stats[key].Value;
			}
		}

		private void Awake()
		{
			InitializeStats();
		}

		private void InitializeStats()
		{
			foreach(Stat stat in baseStats.CharacterStats)
			{
				stats[stat.Name] = stat.DeepCopy();
			}
		}

		public void AddModifier(string stat, StatModifier modifier)
		{
			stats[stat].AddModifier(modifier);
		}

		public void RemoveModifier(string stat, StatModifier modifier)
		{
			stats[stat].RemoveModifier(modifier);
		}
	}
}