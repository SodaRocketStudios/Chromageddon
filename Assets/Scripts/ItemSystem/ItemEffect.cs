using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	[System.Serializable]
	public class ItemEffect
	{
		[SerializeField] private string statName;

		[SerializeField] private StatModifier modifier;

		public void Apply(CharacterStats characterStats)
		{
			characterStats.AddModifier(statName, modifier);s
		}

		public void Remove(CharacterStats characterStats)
		{
			characterStats.RemoveModifier(statName, modifier);
		}
	}
}