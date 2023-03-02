using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatSystem
{
	public class CharacterStats : MonoBehaviour
	{
		[SerializeField] private BaseCharacterStats baseStats;
		public BaseCharacterStats BaseStats
		{
			set
			{
				baseStats = value;
				InitializeStats();
			}
		}

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
			foreach(Stat stat in baseStats.BaseStats)
			{
				stats[stat.Name] = stat.DeepCopy();
			}
		}

		public void AddModifier(string key, StatModifier modifier)
		{
			stats[key].AddModifier(modifier);
		}

		public void RemoveModifier(string key, StatModifier modifier)
		{
			stats[key].RemoveModifier(modifier);
		}
	}
}