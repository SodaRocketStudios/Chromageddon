using UnityEngine;
using System.Collections.Generic;

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
			"AttackArc"
		};

		[SerializeField] private List<Stat> characterStats = new List<Stat>();
		public List<Stat> CharacterStats {get { return characterStats;}}

		private bool hasBeenInitialized = false;

		private void Awake()
		{
			if(hasBeenInitialized) return;

			Initialize();
		}

		[ContextMenu("Reinitialize")]
		private void Initialize()
		{
			characterStats.Clear();
			
			foreach(string stat in stats)
			{
				characterStats.Add(new Stat(stat));
			}

			hasBeenInitialized = true;
		}
	}
}