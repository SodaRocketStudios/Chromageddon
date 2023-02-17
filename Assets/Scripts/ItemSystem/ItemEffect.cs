using UnityEngine;
using SRS.StatSystem;

namespace SRS.ItemSystem
{
	[System.Serializable]
	public class ItemEffect
	{
		[SerializeField] private string statName;

		[SerializeField] private StatModifier modifier;

		public void Apply(CharacterStats stats)
		{
			stats.Character[statName]?.AddModifier(modifier);
			stats.Attack[statName]?.AddModifier(modifier);
		}

		public void Remove(CharacterStats stats)
		{
			stats.Character[statName]?.RemoveModifier(modifier);
			stats.Attack[statName]?.RemoveModifier(modifier);
		}
	}
}