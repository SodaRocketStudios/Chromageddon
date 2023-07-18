using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatSystem
{
	[CreateAssetMenu(fileName = "New Base Character Data", menuName = "Character Data/Character Base Data")]
	public class BaseCharacterStats : ScriptableObject
	{
		private static List<string> stats = new List<string>()
		{
			"Health",
			"Armor",
			"Damage",
			"Speed",
			"Attack Delay",
			"Attack Arc",
			"Range",
			"Critical Chance",
			"Critical Damage",
			"Poison Chance",
			"Burn Chance",
			"Freeze Chance",
			"Health Regen",
			"Pickup Range"
		};

		[SerializeField] private List<Stat> baseStats = new List<Stat>();
		public List<Stat> BaseStats {get { return baseStats;}}

		private void Awake()
		{
			if(baseStats.Count > 0) return;

			Initialize();
		}

		private void Initialize()
		{
			baseStats.Clear();

			foreach(string statName in stats)
			{
				baseStats.Add(new Stat(statName));
			}

			baseStats.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
		}

		[ContextMenu("Update")]
		private void AddNewStats()
		{
			if(baseStats.Count < 1)
			{
				Initialize();
				return;
			}

			foreach(string statName in stats)
			{
				bool createNew = true;

				foreach(Stat stat in baseStats)
				{
					if(stat.Name.CompareTo(statName) == 0)
					{
						createNew = false;
						break;
					}
				}

				if(createNew)
				{
					baseStats.Add(new Stat(statName));
				}
			}

			baseStats.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
		}
	}
}