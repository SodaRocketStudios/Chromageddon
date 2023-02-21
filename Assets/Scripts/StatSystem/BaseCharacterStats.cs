using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRS.StatSystem
{
	[CreateAssetMenu(fileName = "New Base Character Data", menuName = "Character Data/Character Base Data")]
	public class BaseCharacterStats : ScriptableObject
	{
		private static List<string> stats = new List<string>()
		{
			"Health",
			"Shield",
			"Armor",
			"Damage",
			"MoveSpeed",
			"AttackSpeed",
			"AttackArc",
			"ProjectileSpeed",
			"ProjectileLifetime"
		};

		[SerializeField] private List<Stat> characterStats = new List<Stat>();
		public List<Stat> CharacterStats {get { return characterStats;}}

		private bool hasBeenInitialized = false;

		private void Awake()
		{
			if(hasBeenInitialized) return;

			Initialize();
		}

		private void Initialize()
		{
			characterStats.Clear();

			foreach(string statName in stats)
			{
				characterStats.Add(new Stat(statName));
			}

			characterStats.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));

			hasBeenInitialized = true;
		}

		[ContextMenu("Update")]
		private void AddNewStats()
		{
			if(characterStats.Count < 1)
			{
				Initialize();
				return;
			}

			foreach(string statName in stats)
			{
				bool createNew = true;
				
				foreach(Stat stat in characterStats)
				{
					if(stat.Name.CompareTo(statName) == 0)
					{
						createNew = false;
						break;
					}
				}

				if(createNew)
				{
					characterStats.Add(new Stat(statName));
				}
			}

			characterStats.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
		}
	}
}